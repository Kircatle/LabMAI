function main()
{
    let canvas = document.querySelector("#scene3d");
    let scene = canvas.getContext("2d");
    let rangeSectorStep = document.querySelector("#approximation");
    let rangeHeight = document.querySelector("#height");
    let rangeEdge = document.querySelector("#edge");
    let sectorStepCylinder = 2;
    let heightCylinder = 1;
    let edgeCylinder = 1;


    let drag = false;
    let old_x; let old_y;
    let rot_x = 0.; let rot_y = 0.;
    let scale = 0.9;
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

    let rangeHeightHandler = function (e)
    {
        heightCylinder = rangeHeight.value;
    }

    let rangeEdgeHandler = function (e)
    {
        edgeCylinder = rangeEdge.value;
    }

    let rangeHandler = function (e)
    {
        sectorStepCylinder = rangeSectorStep.value;
    }

    rangeEdge.addEventListener("input", rangeEdgeHandler, false);
    rangeHeight.addEventListener("input", rangeHeightHandler, false);
    rangeSectorStep.addEventListener("input", rangeHandler, false);
    canvas.addEventListener("mousedown", mouseDownHandler, false);
    canvas.addEventListener("mouseup", mouseUpHandler, false);
    canvas.addEventListener("mouseout", mouseUpHandler, false);
    canvas.addEventListener("mousemove", mouseMoveHandler, false);
    canvas.addEventListener('wheel',wheelHandler, false);

    let drawScene = function(time)
    {
        let points = getPoints(sectorStepCylinder, edgeCylinder, heightCylinder);
        scene.fillStyle = "rgb(0,0,0)";
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
function getPoints(sectorStep, edge, height)
{
    let vertex = [];
    vertex = vertex.concat(getVertexBase(sectorStep, edge, height));
    vertex = vertex.concat(getVertexSideEdge(sectorStep, edge, height));
    vertex = vertex.concat(getVertexBackEdge(edge, height));
    return vertex;
}

function getVertexSideEdge(sectorStep, edge, height)
{
    let points = [];
    let downTrianglesPlus = getVertexSideEdgeDownTriangles(sectorStep, edge, 1, height);
    let downTrianglesMinus = getVertexSideEdgeDownTriangles(sectorStep, edge, -1, height);
    let upperTrianglesPlus = getVertexSideEdgeUpperTriangles(sectorStep, edge, 1, height);
    let upperTrianglesMinus = getVertexSideEdgeUpperTriangles(sectorStep, edge, -1, height);
    points = points.concat(downTrianglesMinus);
    points = points.concat(downTrianglesPlus);
    points = points.concat(upperTrianglesMinus);
    points = points.concat(upperTrianglesPlus);
    return points
}
function getVertexBackEdge(edge, height)
{
    let points =
        [
            -edge, height, edge*edge,
            edge, height, edge*edge,
            -edge, -height, edge*edge,
            edge, -height, edge*edge,
            -edge, -height, edge*edge,
            edge,height,edge*edge

        ]
    return points
}

function getVertexBase(sectorStep, edge, height)
{
    let points = [];
    let baseDownPlusX = getVertexBaseUpperOrDown(sectorStep, edge, 1, -height);
    let baseDownMinusX = getVertexBaseUpperOrDown(sectorStep, edge,-1, -height);
    let baseUpperPlusX = getVertexBaseUpperOrDown(sectorStep, edge,1, height);
    let baseUpperMinusX = getVertexBaseUpperOrDown(sectorStep, edge,-1, height);
    points = points.concat(baseDownPlusX);
    points = points.concat(baseDownMinusX);
    points = points.concat(baseUpperPlusX);
    points = points.concat(baseUpperMinusX);
    return points;
}
function getVertexBaseUpperOrDown(sectorStep, edge, signX, height)
{
    let points = [];
    let step = edge/sectorStep;
    if (signX === 1 && height >= 0 || signX === -1 && height < 0) {
        for (let i = 0; i < edge; i += step) {
            points.push(signX * i); //x
            points.push(height); //y
            points.push(i * i); //z
            points.push(signX * (i + step)); // x
            points.push(height); //y
            points.push((i + step) * (i + step)); //z
            points.push(0); //x
            points.push(height); //y
            points.push(edge * edge); //z
        }


        if (points[points.length - 6] !== edge) {
            for (let i = 0; i < 9; i++) {
                points.pop();
            }
            points.push(signX * (edge - step));
            points.push(height);
            points.push((edge - step) * (edge - step))
            points.push(edge * signX); //x
            points.push(height); //y
            points.push(edge * edge); //z
            points.push(0); //x
            points.push(height); //y
            points.push(edge * edge); //z
        }
    }
    else if (signX === 1 && height < 0 || signX === -1 && height > 0)
    {
        for (let i = 0; i < edge; i += step) {
            points.push(signX * i); //x
            points.push(height); //y
            points.push(i * i); //z
            points.push(0); //x
            points.push(height); //y
            points.push(edge * edge); //z
            points.push(signX * (i + step)); // x
            points.push(height); //y
            points.push((i + step) * (i + step)); //z

        }


        if (points[points.length - 6] !== edge) {
            for (let i = 0; i < 9; i++) {
                points.pop();
            }
            points.push(signX * (edge - step));
            points.push(height);
            points.push((edge - step) * (edge - step));
            points.push(0); //x
            points.push(height); //y
            points.push(edge * edge); //z
            points.push(edge * signX); //x
            points.push(height); //y
            points.push(edge * edge); //z

        }
    }


    return points;

}


function getVertexSideEdgeDownTriangles(sectorStep,edge, signX, height)
{
    let points = [];
    let step = edge/sectorStep;
    if (signX == 1) {
        for (let i = 0; i < edge - step; i += step) {
            points.push(signX * i); //x
            points.push(-height); //y
            points.push(i * i); //z
            points.push(signX * (i + step)); //x
            points.push(-height); //y
            points.push((i + step) * (i + step)); //z
            points.push(signX * i); //x
            points.push(height); //y
            points.push(i * i); //z
        }
        if (points[points.length - 9] !== (edge - step) * signX && points[points.length - 6] !== edge * signX) {
            points.push((edge - step) * signX); //x
            points.push(-height); //y
            points.push((edge - step) * (edge - step)); //z
            points.push(signX * (edge)); //x
            points.push(-height); //y
            points.push((edge) * (edge)); //z
            points.push(signX * (edge - step)); //x
            points.push(height); //y
            points.push((edge - step) * (edge - step)); //z


        }
    }
    else if (signX == -1)
    {
        for (let i = 0; i < edge - step; i += step)
        {
            points.push(signX * i); //x
            points.push(-height); //y
            points.push(i * i); //z
            points.push(signX * i); //x
            points.push(height); //y
            points.push(i * i); //z
            points.push(signX * (i + step)); //x
            points.push(-height); //y
            points.push((i + step) * (i + step)); //z

        }
        if (points[points.length - 9] !== (edge - step) * signX && points[points.length - 6] !== edge * signX) {
            points.push((edge - step) * signX); //x
            points.push(-height); //y
            points.push((edge - step) * (edge - step)); //z
            points.push(signX * (edge - step)); //x
            points.push(height); //y
            points.push((edge - step) * (edge - step)); //z
            points.push(signX * (edge)); //x
            points.push(-height); //y
            points.push((edge) * (edge)); //z



        }
    }

    return points
}

function getVertexSideEdgeUpperTriangles(sectorStep,edge, signX, height)
{
    let points = [];
    let step = edge/sectorStep;
    if (signX === -1) {
        for (let i = 0; i < edge - step; i += step) {
            points.push(signX * i); //x
            points.push(height); //y
            points.push(i * i); //z
            points.push(signX * (i + step)); //x
            points.push(height); //y
            points.push((i + step) * (i + step)); //z
            points.push(signX * (i + step)); //x
            points.push(-height); //y
            points.push((i + step) * (i + step)); //z
        }
        if (points[points.length - 9] !== (edge - step) * signX && points[points.length - 6] !== edge * signX) {
            points.push((edge - step) * signX); //x
            points.push(height); //y
            points.push((edge - step) * (edge - step)); //z
            points.push(signX * (edge)); //x
            points.push(height); //y
            points.push((edge) * (edge)); //z
            points.push(signX * (edge)); //x
            points.push(-height); //y
            points.push((edge) * (edge)); //z


        }
    }
    else if (signX === 1)
    {
        for (let i = 0; i < edge - step; i += step) {
            points.push(signX * i); //x
            points.push(height); //y
            points.push(i * i); //z

            points.push(signX * (i + step)); //x
            points.push(-height); //y
            points.push((i + step) * (i + step)); //z

            points.push(signX * (i + step)); //x
            points.push(height); //y
            points.push((i + step) * (i + step)); //z
        }
        if (points[points.length - 9] !== (edge - step) * signX && points[points.length - 3] !== edge * signX) {
            points.push((edge - step) * signX); //x
            points.push(height); //y
            points.push((edge - step) * (edge - step)); //z
            points.push(signX * (edge)); //x
            points.push(-height); //y
            points.push((edge) * (edge)); //z

            points.push(signX * (edge)); //x
            points.push(height); //y
            points.push((edge) * (edge)); //z


        }
    }
    return points
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
    }
}

main();
