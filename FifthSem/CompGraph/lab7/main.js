function main()
{
    let canvas = document.querySelector("#scene2d");
    let ctx = canvas.getContext("2d");
    let buttonStart = document.querySelector("#start");
    let buttonClear = document.querySelector("#clear");
    let points = [];
    let pressMouse = false;
    let oldMouseX, oldMouseY;
    let pointIndex;
    let buttonStartPress = false;
    let buttonClearPress = false;
    let onMouseDown = function (e)
    {
        buttonClearPress = false;
        if (!buttonStartPress)
        {
            oldMouseX = e.pageX - e.target.offsetLeft;
            oldMouseY = e.pageY - e.target.offsetTop;
            let createPoint = true;

            for (let i = 0; i < points.length; i += 2)
            {
                if (Math.abs(oldMouseX - points[i]) <= 5 && Math.abs(oldMouseY - points[i + 1]) <= 5) {
                    pointIndex = i;
                    pressMouse = true;
                    createPoint = false;
                }
            }
            if (points.length === 12)
            {
                createPoint = false;
            }
            if (createPoint)
            {
                points.push(oldMouseX, oldMouseY)
                ctx.beginPath();
                ctx.arc(oldMouseX, oldMouseY, 5, 0, 2 * Math.PI, true);
                ctx.fill();
                ctx.stroke();
            }
        }
        else
        {
            oldMouseX = e.pageX - e.target.offsetLeft;
            oldMouseY = e.pageY - e.target.offsetTop;
            for (let i = 0; i < 12; i += 2) {
                if (Math.abs(oldMouseX - points[i]) <= 5 && Math.abs(oldMouseY - points[i + 1]) <= 5) {
                    pointIndex = i;
                    pressMouse = true;
                }
            }
        }
        e.preventDefault();
    }
    let onMouseMove = function (e)
    {
        if (!pressMouse)
        {
            return false
        }
        let newMouseY = e.pageY - e.target.offsetTop,
            newMouseX = e.pageX - e.target.offsetLeft;
        points[pointIndex] = newMouseX;
        points[pointIndex+1] = newMouseY;
        ctx.clearRect(0, 0, canvas.clientWidth, canvas.clientHeight);
        for (let i = 0; i < points.length; i += 2)
        {
            ctx.beginPath();
            ctx.arc(points[i], points[i+1], 5, 0, 2 * Math.PI, true);
            ctx.fill();
            ctx.stroke();
        }
        e.preventDefault();
    }

    let onMouseUp = function (e)
    {
        pressMouse = false;
        e.preventDefault();
    }

    let onButtonStartPress = function (e)
    {
        buttonStartPress = true;
        buttonClearPress = false;
        requestAnimationFrame(drawScene);
        e.preventDefault();
    }
    let onButtonClearPress = function (e)
    {
        ctx.clearRect(0,0,canvas.clientWidth, canvas.clientHeight);
        points = [];
        buttonClearPress = true;
        e.preventDefault();
    }
    buttonStart.addEventListener("click", onButtonStartPress, false);
    buttonClear.addEventListener("click", onButtonClearPress, false);
    canvas.addEventListener("mousedown", onMouseDown, false);
    canvas.addEventListener("mousemove", onMouseMove, false);
    canvas.addEventListener("mouseup", onMouseUp, false);

    let drawScene = function(time)
    {
        ctx.clearRect(0, 0, canvas.clientWidth, canvas.clientHeight);
        for (let i = 0; i < 12; i += 2)
        {
            ctx.beginPath();
            ctx.arc(points[i], points[i+1], 5, 0, 2 * Math.PI, true);
            ctx.fill();
            ctx.stroke();
        }
        let plot = generatePoints(points, canvas.clientWidth, canvas.clientHeight);

        ctx.beginPath();
        for (let i = 0; i < plot[0].length-1; i++)
        {
            ctx.moveTo(plot[0][i],plot[1][i])
            ctx.lineTo(plot[0][i+1], plot[1][i+1])
        }
        ctx.stroke();
        if (buttonClearPress)
        {
            buttonClearPress = false;
            buttonStartPress = false;
            points = [];
            ctx.clearRect(0,0,canvas.clientWidth,canvas.clientHeight);
            return false;
        }
       requestAnimationFrame(drawScene);

    }

}


function generatePoints(points, canvasWidth, canvasHeight)
{
    let xList = [];
    let yList = [];
    let xPoints = [];
    let yPoints = [];
    convertTo.coordinates(points, canvasWidth, canvasHeight);
    for (let i = 0; i<12; i+=2)
    {
       xPoints.push(points[i]);
       yPoints.push(points[i+1]);
    }
    for (let x = -1; x<1; x+=0.01)
    {
        xList.push(x);
    }
    for (let i = 0; i<xList.length; i++)
    {
        yList.push(poly(xList[i], xPoints, yPoints));
    }

    convertTo.pixels(points, canvasWidth, canvasHeight);
    convertTo.xPixels(xList, canvasWidth);
    convertTo.yPixels(yList, canvasHeight);
    return [xList, yList]

}

let convertTo = {

    pixels: function (points, canvasWidth, canvasHeight)
    {
        for (let i = 0; i < points.length; i+=2) {
            let x = ((points[i] + 1) / 2) * canvasWidth;
            let y = ((-points[i+1] + 1) / 2) * canvasHeight;
            points[i] = x;
            points[i+1] = y;
        }
        return points;
    },
    coordinates:  function(points, canvasWidth, canvasHeight)
    {
        for (let i = 0; i < points.length; i+=2)
        {
            let x = (2*points[i]/canvasWidth-1)
            let y = -(2*points[i+1]/canvasHeight-1);
            points[i] = x;
            points[i+1] = y;
        }
        return points
    },
    xPixels: function (x, canvasWidth)
    {
        for (let i = 0; i< x.length; i+=1)
        {
            x[i] = (x[i]+1)/2*canvasWidth;
        }
        return x;
    },
    yPixels: function (y, canvasHeight)
    {
        for (let i = 0; i < y.length; i+=1)
        {
            y[i] = ((-y[i] + 1) / 2) * canvasHeight;
        }
        return y;
    },
}



function poly(x, xPoints, yPoints)
{
    let phi;
    let poly = 0;
    for (let i = 0; i<6; i++)
    {
        phi = 1;
        for (let j = 0; j<6; j++)
        {
            if (i !== j)
            {
                phi *= (x - xPoints[j])/(xPoints[i] - xPoints[j]);
            }
        }
        poly += phi*yPoints[i];
    }
    return poly;

}

main();