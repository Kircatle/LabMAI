function main()
{
    let canvas = document.querySelector("#scene3d");
    let textP00 = document.querySelector("#P00");
    let textP01 = document.querySelector("#P01");
    let textP10 = document.querySelector("#P10");
    let textP11 = document.querySelector("#P11");
    let pNewButton = document.querySelector("#pNew");
    let scene = canvas.getContext("2d");
    let P00 = [-0.8,-0.8,0.8],
        P01 = [0.8,0.8,0.8],
        P10 = [0.8,-0.8,-0.8],
        P11 = [-0.8,0.8,-0.8];
    let P = [P00, P01, P10, P11];
    let drag = false;
    let old_x; let old_y;
    let rot_x = 0.; let rot_y = 0.;
    let scale = 0.9;

    let pNewButtonHandler = function (e)
    {
        let P00_tmp = textP00.value.split(",").map(Number);
        let P01_tmp = textP01.value.split(",").map(Number);
        let P10_tmp = textP10.value.split(",").map(Number);
        let P11_tmp = textP11.value.split(",").map(Number);
        P = [P00_tmp, P01_tmp, P10_tmp, P11_tmp];
        e.preventDefault();
    }
    let mouseDownHandler = function (e)
    {
        drag = true;
        old_x = e.pageX;
        old_y = e.pageY;
        e.preventDefault();
    }
    let mouseUpHandler = function (e)
    {
        drag = false;
        e.preventDefault();
    }
    let mouseMoveHandler = function (e)
    {
        if (!drag)
        {
            return false;
        }

        let newX = old_x - e.pageX;
        let newY = old_y - e.pageY;

        rot_x += newX * 2 * Math.PI / canvas.clientWidth;
        rot_y += newY * 2 * Math.PI / canvas.clientHeight;

        old_x = e.pageX;
        old_y = e.pageY;

        e.preventDefault();
    }
    let wheelHandler = function (e)
    {
        scale += e.deltaY/1000;
        e.preventDefault();
    }


    pNewButton.addEventListener("click", pNewButtonHandler, false);
    canvas.addEventListener("mousedown", mouseDownHandler, false);
    canvas.addEventListener("mouseup", mouseUpHandler, false);
    canvas.addEventListener("mouseout", mouseUpHandler, false);
    canvas.addEventListener("mousemove", mouseMoveHandler, false);
    canvas.addEventListener('wheel',wheelHandler, false);

    let drawScene = function(time)
    {
        let points = getPoints(P);
        scene.fillStyle = "rgb(255,255,255)";
        scene.fillRect(0,0,canvas.clientHeight,canvas.clientWidth);
        for (let i = 0; i<points.length; i+=9)
        {
            let trianglePoints = [];
            for (let j = 0; j<9; j++)
            {
                trianglePoints.push(points[i+j]);
            }
            let angles = [rot_y, rot_x, 0];
            drawTriangle(scene, trianglePoints, angles, scale);
        }
        requestAnimationFrame(drawScene);

    }

    requestAnimationFrame(drawScene);

}


function drawTriangle(scene, trianglePoints, angles, scale)
{
    let point1 = [trianglePoints[0], trianglePoints[1], trianglePoints[2]]; // [x,y,z]
    let point2 = [trianglePoints[3], trianglePoints[4], trianglePoints[5]];
    let point3 = [trianglePoints[6], trianglePoints[7], trianglePoints[8]];

    point1 = functions3d.rotatePoint(point1, angles)
    point2 = functions3d.rotatePoint(point2, angles)
    point3 = functions3d.rotatePoint(point3, angles)
    let normal = getNormal(point1,point2,point3);
    point1 = functions3d.projectPointTo2d(point1, scale);
    point2 = functions3d.projectPointTo2d(point2, scale);
    point3 = functions3d.projectPointTo2d(point3, scale);
    let light =Math.abs(functions3d.dot(functions3d.normalize(normal),functions3d.normalize([0,0,-1])));
    let g = String(Math.floor(0*light));
    let r = String(Math.floor(139*light));
    let b = String(Math.floor(0*light));
    let color = "rgb("+r+","+g+","+b+")";
    scene.strokeStyle = color;
    point1 = convertToPixels(point1, scene.canvas.height, scene.canvas.width);
    point2 = convertToPixels(point2, scene.canvas.height, scene.canvas.width);
    point3 = convertToPixels(point3, scene.canvas.height, scene.canvas.width);
    if (isVisible(point1,point2,point3)) {
        scene.fillStyle = color;
        scene.beginPath()
        scene.moveTo(point1[0], point1[1]);
        scene.lineTo(point2[0], point2[1]);
        scene.lineTo(point3[0], point3[1]);
        scene.lineTo(point1[0], point1[1]);
        scene.fill();
        scene.closePath();
        scene.stroke();
    }
}



function getNormal(point1, point2, point3)
{
    let vector1 = [point2[0]-point1[0], point2[1]-point1[1], point2[2]-point1[2]];
    let vector2 = [point3[0]-point1[0], point3[1]-point1[1], point3[2]-point1[2]];
    let x1 = vector1[0], x2 = vector2[0];
    let y1 = vector1[1], y2 = vector2[1];
    let z1 = vector1[2], z2 = vector2[2];
    let xNorm = y1*z2-y2*z1;
    let yNorm = -(x1*z2-x2*z1);
    let zNorm = x1*y2 - x2*y1;
    return [xNorm,yNorm,zNorm];
}
function isVisible(point1,point2,point3)
{
    let vector1 = [point2[0]-point1[0], point2[1]-point1[1], point2[2]-point1[2]];
    let vector2 = [point3[0]-point1[0], point3[1]-point1[1], point3[2]-point1[2]];
    let x1 = vector1[0], x2 = vector2[0];
    let y1 = vector1[1], y2 = vector2[1];
    let zNorm = x1*y2 - x2*y1;

    return zNorm<0;


}


function convertToPixels(point, canvasHeight, canvasWidth)
{
    let x = ((point[0] + 1) / 2) * canvasWidth;
    let y = ((-point[1] + 1) / 2) * canvasHeight;
    return [x, y];
}

function getPoints(P)
{
    let vertex = []
    let step = 0.05
    for (let x = 0; x < 1; x += step) {
        for (let y = 0; y < 1; y += step) {
            let a1 = getPointQ(x, y, P);
            let a2 = getPointQ(x + step, y, P);
            let a3 = getPointQ(x, y + step, P);
            let a4 = getPointQ(x + step, y + step, P);
            vertex.push(a1[0], a1[1], a1[2]);
            vertex.push(a2[0], a2[1], a2[2]);
            vertex.push(a3[0], a3[1], a3[2]);
            vertex.push(a4[0], a4[1], a4[2]);
            vertex.push(a3[0], a3[1], a3[2]);
            vertex.push(a2[0], a2[1], a2[2]);
            vertex.push(a1[0], a1[1], a1[2]);
            vertex.push(a3[0], a3[1], a3[2]);
            vertex.push(a2[0], a2[1], a2[2]);
            vertex.push(a4[0], a4[1], a4[2]);
            vertex.push(a2[0], a2[1], a2[2]);
            vertex.push(a3[0], a3[1], a3[2]);
        }
    }
    return vertex;
}
function getPointQ(u, w, P)
{
    let P00 = P[0],
        P01 = P[1],
        P10 = P[2],
        P11 = P[3];
    let num1 = (1 - u) * (1 - w);
    let v1 = functions3d.numMultVectors(P00, num1);
    let num2 = (1 - u) * w;
    let v2 = functions3d.numMultVectors(P01, num2);
    let sumVect1 = functions3d.addVectors(v1, v2);

    num1 = (1 - w) * u;
    v1 = functions3d.numMultVectors(P10, num1);
    num2 = u * w;
    v2 = functions3d.numMultVectors(P11, num2);
    let sumVect2 = functions3d.addVectors(v1, v2);

    return functions3d.addVectors(sumVect1, sumVect2);
}


let functions3d = {

    dot: function (a, b)
    {
        return a[0]*b[0]+a[1]*b[1]+a[2]*b[2];
    },

    projectionAndScale: function(scale)
    {
        let matrix = [
                [scale, 0, 0],
                [0, scale, 0],
            ];
        return matrix;
    },


    matMul: function(A, B) {
        let rowsA = A.length, colsA = A[0].length,
            rowsB = B.length, colsB = B[0].length,
            C = [];
        let temp;

        if (colsA !== rowsB)
        {
            alert("Ошибка");
            console.log("Невозможно умножить матрицы");
            return null;
        }

        for (let i = 0; i < rowsA; i++)
        {
            C[i] = [];
        }
        for (let i = 0; i < rowsA; i++)
        {
            for (let j = 0; j < colsB; j++)
            {
                temp = 0;
                for (let k = 0; k < colsA; k++)
                {
                    temp += A[i][k] * B[k][j]
                }
                C[i][j] = temp;
            }
        }
        return C;
    },

    pointToMatrix: function(point) {
        let matrix = [[],[],[]];
        matrix[0][0] = point[0];
        matrix[1][0] = point[1];
        if (point.length === 3)
        {
            matrix[2][0] = point[2];
            return matrix;
        }
        matrix[2][0] = 0;
        matrix.pop();
        return matrix;

    },

    matToPoint: function(matrix) {
        let x = matrix[0][0];
        let y = matrix[1][0];
        if (matrix.length === 3) {
            let z = matrix[2][0];
            return [x, y, z];
        }
        return [x, y];
    },

    matrixRotateZ: function (angle) {
        let matrix = [
            [Math.cos(angle), -Math.sin(angle), 0],
            [Math.sin(angle), Math.cos(angle), 0],
            [0, 0, 1],
        ];
        return matrix;
    },

    matrixRotateY: function (angle)
    {
        let matrix = [
            [Math.cos(angle), 0, -Math.sin(angle)],
            [0, 1, 0],
            [Math.sin(angle), 0, Math.cos(angle)],
        ];

        return matrix;
    },

    matrixRotateX: function (angle) {
        let matrix = [
            [1, 0, 0],
            [0, Math.cos(angle), -Math.sin(angle)],
            [0, Math.sin(angle), Math.cos(angle)],
        ];
        return matrix;
    },

    rotateZ: function(point, angle) {
        point = this.pointToMatrix(point);
        let rotatedPoint = this.matToPoint(this.matMul(this.matrixRotateZ(angle), point));
        return rotatedPoint;
    },

    rotateY: function (point, angle) {
        point = this.pointToMatrix(point);
        let rotatedPoint = this.matToPoint(this.matMul(this.matrixRotateY(angle), point));
        return rotatedPoint;
    },


    rotateX: function(point, angle) {
        point = this.pointToMatrix(point);
        let rotatedPoint = this.matToPoint(this.matMul(this.matrixRotateX(angle), point));
        return rotatedPoint;
    },

    projectPointTo2d: function(point, scale) {
        point = this.pointToMatrix(point)
        let projectedPoint = this.matToPoint(this.matMul(this.projectionAndScale(scale), point));
        return projectedPoint;
    },

    rotatePoint: function(point, angles) {
        point = this.rotateX(point, angles[0]);
        point = this.rotateY(point, angles[1]);
        point = this.rotateZ(point, angles[2]);
        return point;
    },
    normalize: function(v, dst)
    {
        dst = dst || new Float32Array(3);
        let length = Math.sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
        if (length > 0.00001) {
            dst[0] = v[0] / length;
            dst[1] = v[1] / length;
            dst[2] = v[2] / length;
        }
        return dst;
    },

    addVectors: function(v1,v2) {
        return [v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2]];
    },

    numMultVectors:function (v1,num) {
        return [v1[0] * num, v1[1] * num, v1[2] * num];
    },
}

main();
