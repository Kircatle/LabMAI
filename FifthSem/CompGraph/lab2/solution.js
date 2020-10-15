window.onload = function()
{

    let canvas = document.getElementById("prism");
    let gl = canvas.getContext("webgl");
    resize(gl.canvas);
    if (!gl)
    {
        alert("Ваш браузер не поддерживает WebGL");
        return false;
    }
    let vertexShaderSource = document.querySelector("#vertex-shader-2d").text;
    let fragmentShaderSource = document.querySelector("#fragment-shader-2d").text;
    let vertexShader = createShader(gl, gl.VERTEX_SHADER, vertexShaderSource);
    let fragmentShader = createShader(gl, gl.FRAGMENT_SHADER, fragmentShaderSource);
    let program = createProgram(gl, vertexShader, fragmentShader);
    let a_position =  gl.getAttribLocation(program, "a_position"); //получение ссылки на a_position
    let positionBuffer = gl.createBuffer(); //создание буффера для точек
    gl.bindBuffer(gl.ARRAY_BUFFER, positionBuffer); //линковка буффера с gl.array_buffer
    let positions = [
        0, 0,
        0, -1,
        0.7, 0,
    ];
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(positions), gl.STATIC_DRAW); //заполнение буфера
    gl.viewport(0, 0, gl.canvas.width, gl.canvas.height); //как координаты преобразовывать в пиксили
    gl.clearColor(0, 0, 0, 0); //очистка canvas
    gl.clear(gl.COLOR_BUFFER_BIT);
    gl.useProgram(program); //говорим использовать программу
    gl.enableVertexAttribArray(a_position);
    let size = 2;          // 2 компоненты на итерацию
    let type = gl.FLOAT;   // наши данные - 32-битные числа с плавающей точкой
    let normalize = false; // не нормализовать данные
    let stride = 0;        // 0 = перемещаться на size * sizeof(type) каждую итерацию для получения следующего положения
    let offset = 0;        // начинать с начала буфера
    gl.vertexAttribPointer(a_position, size, type, normalize, stride, offset) // как извлекать данные из буфера
    var primitiveType = gl.LINE_LOOP;
    var count = 3;
    gl.drawArrays(primitiveType, offset, count);


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


function createProgram(gl, vertexShader, fragmentShader) {
    var program = gl.createProgram();
    gl.attachShader(program, vertexShader);
    gl.attachShader(program, fragmentShader);
    gl.linkProgram(program);
    var success = gl.getProgramParameter(program, gl.LINK_STATUS);
    if (success) {
        return program;
    }

    console.log(gl.getProgramInfoLog(program));
    gl.deleteProgram(program);
    alert("Не удалось связать Шейдеры");
}

function resize(canvas) {
    // получаем размер HTML-элемента canvas
    var displayWidth  = canvas.clientWidth;
    var displayHeight = canvas.clientHeight;

    // проверяем, отличается ли размер canvas
    if (canvas.width  != displayWidth || canvas.height != displayHeight)
    {

        // подгоняем размер буфера отрисовки под размер HTML-элемента
        canvas.width  = displayWidth;
        canvas.height = displayHeight;
    }
}

