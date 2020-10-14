/*
Сыроежкин Кирилл М8О-304Б-18
Вариант 16.
Условие задачи: написать и отладить программу, строящую изображение заданной замечательной кривой.
Кривая: y^2 = x^2 * (a-x)/(a+x).
 */


//Положительная часть исходной функции
function f1(x,a)
{
    return Math.sqrt(x*x*(a-x)/(a+x));
}

//Отрицательная часть исходной функции
function f2(x,a)
{
    return -Math.sqrt(x*x*(a-x)/(a+x));
}

//Получение точек x и y из функций
function generateXY(f, a)
{
    let arrY = [];
    let arrX = [];
    let x = -a+0.01;
    for (let x=-a+0.01; x<=a; x+=0.01)
    {
        arrX.push(x);
        arrY.push(f(x,a));
    }
    arrX.push(a);
    arrY.push(0);
    return [arrX, arrY];
}

//Рисование графика
function plotGraph(graph, layout, options)
{
    let a = Number(document.getElementById("valueA").value);
    let A = Number(document.getElementById("valueBigA").value);
    let B = Number(document.getElementById("valueBigB").value);
    let arr1 = generateXY(f1, a);
    let arr2 = generateXY(f2, a);
    let data1 = [
        {
            x: arr1[0],
            y: arr1[1],
            mode: 'scatter',
        }
    ]
    let data2 = [
        {
            x: arr2[0],
            y: arr2[1],
            mode: 'scatter',
        }
    ]
    layout["xaxis"] = {range: [A, B], title: 'OX'};
    layout["yaxis"] = {range: [A, B], title: 'OY'};
    Plotly.newPlot(graph, data1, layout, options);
    Plotly.plot(graph, data2, layout, options);
}


let graph = document.getElementById('graph');
let data = [];
//Подборка нужных параметров для красивого отображения
let layout = {
    autosize: false,
    showlegend: false,
    width: 700,
    height: 600,
    dragmode: 'pan',
    colorway: ['#4e4eff'],
    xaxis: {range: [-10, 10], title: 'OX'},
    yaxis: {range: [-10, 10], title: 'OY'}
};
options = {
    displayModeBar: false,
    scrollZoom: true
}
//Пустой график
Plotly.newPlot(graph, data, layout, options);



