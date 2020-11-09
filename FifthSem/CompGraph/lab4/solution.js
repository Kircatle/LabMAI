function main()
{
    let scene3d = document.querySelector("#scene3d");
    let rangeSectorStep = document.querySelector("#approximation");
    let rangeHeight = document.querySelector("#height");
    let rangeEdge = document.querySelector("#edge");
    let gl = scene3d.getContext("webgl");
    let program = createProgram(gl);
    let positionLocation = gl.getAttribLocation(program, "a_position");
    let colorLocation = gl.getUniformLocation(program, 'u_FragColor');
    let matrixLocation = gl.getUniformLocation(program, "u_matrix");
    gl.enableVertexAttribArray(positionLocation);
    gl.enable(gl.DEPTH_TEST);
    let drag = false;
    let old_x; let old_y;
    let rot_x = 0.; let rot_y = 0.;
    let scale = 0.9;
    let sectorStep = 1;
    let rotation = [];
    let height = 0.5;
    let edge = 1;


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
        if (!drag) {
            return false;
        };

        let newX = old_x - e.pageX;
        let newY = old_y - e.pageY;

        rot_x += newX * 2 * Math.PI / scene3d.width;
        rot_y += newY * 2 * Math.PI / scene3d.height;

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
        height = rangeHeight.value;
    }

    let rangeEdgeHandler = function (e)
    {
        edge = rangeEdge.value;
    }

    let rangeHandler = function (e)
    {
        sectorStep = rangeSectorStep.value;
    }

    rangeEdge.addEventListener("input", rangeEdgeHandler, false);
    rangeHeight.addEventListener("input", rangeHeightHandler, false);
    rangeSectorStep.addEventListener("input", rangeHandler, false);
    scene3d.addEventListener("mousedown", mouseDownHandler, false);
    scene3d.addEventListener("mouseup", mouseUpHandler, false);
    scene3d.addEventListener("mouseout", mouseUpHandler, false);
    scene3d.addEventListener("mousemove", mouseMoveHandler, false);
    scene3d.addEventListener('wheel',wheelHandler, false);


    let drawScene = function (time)
    {
        rotation=[rot_y, rot_x, 0];
        let positionBuffer = gl.createBuffer();
        gl.bindBuffer(gl.ARRAY_BUFFER, positionBuffer);
        setVertex(gl, sectorStep, edge, height);
        gl.useProgram(program);
        let matrix = m4.identity();
        matrix = m4.scale(matrix, scale, scale, scale);
        matrix = m4.xRotate(matrix, rotation[0]);
        matrix = m4.yRotate(matrix, rotation[1]);
        matrix = m4.zRotate(matrix, rotation[2]);
        let size = 3;
        let type = gl.FLOAT;
        let normalize = false;
        let stride = 0;
        let offset = 0;
        gl.clearColor(0, 0, 0, 0);
        gl.clear(gl.COLOR_BUFFER_BIT);
        gl.vertexAttribPointer(positionLocation, size, type, normalize, stride, offset);
        gl.uniformMatrix4fv(matrixLocation, false, matrix);
        gl.uniform4f(colorLocation, 1,0.4,1, 1);
        gl.drawArrays(gl.TRIANGLES,0,3000);


        requestAnimationFrame(drawScene)
    }
    requestAnimationFrame(drawScene)
}


function setVertex(gl, sectorStep, edge, height)
{
    let vertex = [];
    vertex = vertex.concat(getVertexBase(sectorStep, edge, height));
    vertex = vertex.concat(getVertexSideEdge(sectorStep, edge, height));
    vertex = vertex.concat(getVertexBackEdge(edge, height));
    console.log(vertex);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(vertex), gl.STATIC_DRAW);
}

function getVertexSideEdge(sectorStep, edge, height)
{
    let points = [];
    let downTrianglesPlus = getVertexSideEdgeDownTriangles(sectorStep, edge, 1, height);
    let downTrianglesMinus = getVertexSideEdgeDownTriangles(sectorStep, edge, -1, height);
    let upperTrianglesPlus = getVertexSideEdgeUpperTriangles(sectorStep, edge, 1, height);
    let upperTrianglesMinus = getVertexSideEdgeUpperTriangles(sectorStep, edge, -1, height);
    points = points.concat(downTrianglesMinus);
    points = points.concat(downTrianglesPlus)
    points = points.concat(upperTrianglesMinus);
    points = points.concat(upperTrianglesPlus);
    return points
}
function getVertexBackEdge(edge, height)
{
    let points =
        [
            edge, height, edge*edge,
            -edge, height, edge*edge,
            -edge, -height, edge*edge,
            -edge, -height, edge*edge,
            edge, -height, edge*edge,
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
    for (let i = 0; i <= edge ;  i+=step )
    {
        points.push(signX*i); //x
        points.push(height); //y
        points.push(i*i); //z
        points.push(signX*(i+step)); // x
        points.push(height); //y
        points.push((i+step)*(i+step)); //z
        points.push(0); //x
        points.push(height); //y
        points.push(edge*edge); //z
    }
    if (points[points.length-6] !== edge)
    {
        for (let i = 0; i < 6; i++)
        {
            points.pop();
        }
        points.push(edge*signX); //x
        points.push(height); //y
        points.push(edge*edge); //z
        points.push(0); //x
        points.push(height); //y
        points.push(edge*edge); //z

    }
    return points
}


function getVertexSideEdgeDownTriangles(sectorStep,edge, signX, height)
{
    let points = [];
    let step = edge/sectorStep;
    for (let i = 0; i<edge-step; i+=step)
    {
        points.push(signX*i); //x
        points.push(-height); //y
        points.push(i*i); //z
        points.push(signX*(i+step)); //x
        points.push(-height); //y
        points.push((i+step)*(i+step)); //z
        points.push(signX*i); //x
        points.push(height); //y
        points.push(i*i); //z
    }
    if (points[points.length-9] !== (edge-step)*signX && points[points.length-6] !== edge*signX)
    {
        points.push((edge-step)*signX); //x
        points.push(-height); //y
        points.push((edge-step)*(edge-step)); //z
        points.push(signX*(edge)); //x
        points.push(-height); //y
        points.push((edge)*(edge)); //z
        points.push(signX*(edge-step)); //x
        points.push(height); //y
        points.push((edge-step)*(edge-step)); //z


    }
    return points
}

function getVertexSideEdgeUpperTriangles(sectorStep,edge, signX, height)
{
    let points = [];
    let step = edge/sectorStep;
    for (let i = 0; i<edge-step; i+=step)
    {
        points.push(signX*i); //x
        points.push(height); //y
        points.push(i*i); //z
        points.push(signX*(i+step)); //x
        points.push(height); //y
        points.push((i+step)*(i+step)); //z
        points.push(signX*(i+step)); //x
        points.push(-height); //y
        points.push((i+step)*(i+step)); //z
    }
    if (points[points.length-9] !== (edge-step)*signX && points[points.length-6] !== edge*signX)
    {
        points.push((edge-step)*signX); //x
        points.push(height); //y
        points.push((edge-step)*(edge-step)); //z
        points.push(signX*(edge)); //x
        points.push(height); //y
        points.push((edge)*(edge)); //z
        points.push(signX*(edge)); //x
        points.push(-height); //y
        points.push((edge)*(edge)); //z


    }
    return points
}

function createShader(gl, type, source)
{
    let shader = gl.createShader(type);
    gl.shaderSource(shader, source);
    gl.compileShader(shader);
    let success = gl.getShaderParameter(shader, gl.COMPILE_STATUS);
    if (success) {
        return shader;
    }
    console.log(gl.getShaderInfoLog(shader));
    gl.deleteShader(shader);
    alert("Не удалось создать шейдер");
}

function createProgram(gl)
{
    let program = gl.createProgram();
    let vertexShaderSource = document.querySelector("#vertex-shader-2d").text;
    let fragmentShaderSource = document.querySelector("#fragment-shader-2d").text;
    let vertexShader = createShader(gl, gl.VERTEX_SHADER, vertexShaderSource);
    let fragmentShader = createShader(gl, gl.FRAGMENT_SHADER, fragmentShaderSource);
    gl.attachShader(program, vertexShader);
    gl.attachShader(program, fragmentShader);
    gl.linkProgram(program);
    if (gl.getProgramParameter(program, gl.LINK_STATUS)) {
        return program;
    }
    console.log(gl.getProgramInfoLog(program));
    gl.deleteProgram(program);
    alert("Не удалось связать Шейдеры");
}

function smartReverse(array, sizeGroup)
{
    let newArray = [];
    for (let i=array.length; i>0; i-=sizeGroup)
    {
        for (let j = sizeGroup; j >= 1; j--)
        {
            newArray.push(array[i-j]);
        }
    }
    return newArray;
}
main();

let m4 = {

    xRotate: function(m, angleInRadians) {
        return m4.multiply(m, m4.xRotation(angleInRadians));
    },

    yRotate: function(m, angleInRadians) {
        return m4.multiply(m, m4.yRotation(angleInRadians));
    },

    zRotate: function(m, angleInRadians) {
        return m4.multiply(m, m4.zRotation(angleInRadians));
    },
    translate: function(m, tx, ty, tz) {
        return m4.multiply(m, m4.translation(tx, ty, tz));
    },
    scale: function(m, sx, sy, sz) {
        return m4.multiply(m, m4.scaling(sx, sy, sz));
    },
    xRotation: function(angleInRadians) {
        let c = Math.cos(angleInRadians);
        let s = Math.sin(angleInRadians);

        return [
            1, 0, 0, 0,
            0, c, s, 0,
            0, -s, c, 0,
            0, 0, 0, 1,
        ];
    },
    scaling: function(sx, sy, sz) {
        return [
            sx, 0,  0,  0,
            0, sy,  0,  0,
            0,  0, sz,  0,
            0,  0,  0,  1,
        ];
    },
    translation: function(tx, ty, tz) {
        return [
            1,  0,  0,  0,
            0,  1,  0,  0,
            0,  0,  1,  0,
            tx, ty, tz, 1,
        ];
    },
    yRotation: function(angleInRadians) {
        var c = Math.cos(angleInRadians);
        var s = Math.sin(angleInRadians);

        return [
            c, 0, -s, 0,
            0, 1, 0, 0,
            s, 0, c, 0,
            0, 0, 0, 1,
        ];
    },

    zRotation: function(angleInRadians) {
        var c = Math.cos(angleInRadians);
        var s = Math.sin(angleInRadians);

        return [
            c, s, 0, 0,
            -s, c, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1,
        ];
    },
    multiply: function(a, b) {
        let a00 = a[0 * 4 + 0];
        let a01 = a[0 * 4 + 1];
        let a02 = a[0 * 4 + 2];
        let a03 = a[0 * 4 + 3];
        let a10 = a[1 * 4 + 0];
        let a11 = a[1 * 4 + 1];
        let a12 = a[1 * 4 + 2];
        let a13 = a[1 * 4 + 3];
        let a20 = a[2 * 4 + 0];
        let a21 = a[2 * 4 + 1];
        let a22 = a[2 * 4 + 2];
        let a23 = a[2 * 4 + 3];
        let a30 = a[3 * 4 + 0];
        let a31 = a[3 * 4 + 1];
        let a32 = a[3 * 4 + 2];
        let a33 = a[3 * 4 + 3];
        let b00 = b[0 * 4 + 0];
        let b01 = b[0 * 4 + 1];
        let b02 = b[0 * 4 + 2];
        let b03 = b[0 * 4 + 3];
        let b10 = b[1 * 4 + 0];
        let b11 = b[1 * 4 + 1];
        let b12 = b[1 * 4 + 2];
        let b13 = b[1 * 4 + 3];
        let b20 = b[2 * 4 + 0];
        let b21 = b[2 * 4 + 1];
        let b22 = b[2 * 4 + 2];
        let b23 = b[2 * 4 + 3];
        let b30 = b[3 * 4 + 0];
        let b31 = b[3 * 4 + 1];
        let b32 = b[3 * 4 + 2];
        let b33 = b[3 * 4 + 3];
        return [
            b00 * a00 + b01 * a10 + b02 * a20 + b03 * a30,
            b00 * a01 + b01 * a11 + b02 * a21 + b03 * a31,
            b00 * a02 + b01 * a12 + b02 * a22 + b03 * a32,
            b00 * a03 + b01 * a13 + b02 * a23 + b03 * a33,
            b10 * a00 + b11 * a10 + b12 * a20 + b13 * a30,
            b10 * a01 + b11 * a11 + b12 * a21 + b13 * a31,
            b10 * a02 + b11 * a12 + b12 * a22 + b13 * a32,
            b10 * a03 + b11 * a13 + b12 * a23 + b13 * a33,
            b20 * a00 + b21 * a10 + b22 * a20 + b23 * a30,
            b20 * a01 + b21 * a11 + b22 * a21 + b23 * a31,
            b20 * a02 + b21 * a12 + b22 * a22 + b23 * a32,
            b20 * a03 + b21 * a13 + b22 * a23 + b23 * a33,
            b30 * a00 + b31 * a10 + b32 * a20 + b33 * a30,
            b30 * a01 + b31 * a11 + b32 * a21 + b33 * a31,
            b30 * a02 + b31 * a12 + b32 * a22 + b33 * a32,
            b30 * a03 + b31 * a13 + b32 * a23 + b33 * a33,
        ];
    },
    identity: function ()
    {
        return [
            1, 0,  0,  0,
            0, 1,  0,  0,
            0,  0, 1,  0,
            0,  0,  0,  1,
        ]
    }
};
