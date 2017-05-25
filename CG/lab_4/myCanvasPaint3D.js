"use strict";
function Point(x,y,z){
    return {
        x: x,
        y: y,
        z: z
    };
}
function Line(startP, endP){
    return {
        start: startP,
        end: endP
    };
}
function Poly(pointsArray){
    if  (typeof(pointsArray.prototype) === 'Array') and (typeof(pointsArray[0]) === 'Point')
        return pointsArray;
}

function canvasPaint(canvasID,startX,endX,startY,endY,startZ,endZ){
    //private variables
    var that = this,
        canvas = document.getElementById(canvasID),
        context = canvas.getContext('2d'),

        width = canvas.width,
        height = canvas.height,

        coef = 0,//user coordinates to screen (pixels in one user unit)

        zeroX = width / 2,
        zeroY = height / 2,

        points = [],
        lines = [],
        polys = [],

        pointsColor = [],
        linesColor = [],
        polysColor = [],
        pointsText = [],

        transformMatrix = [[1,0,0,0],
                            [0,1,0,0],
                            [0,0,1,0],
                            [0,0,0,1]], //initial - matrix, that don't transforms points

        xStart = Point(startX, 0, 0),
        xEnd = Point(endX, 0, 0),
        yStart = Point(0, startY, 0),
        yEnd = Point(0, endY,0),
        zStart = Point(0, 0, startZ),
        zEnd = Point(0, 0, endZ);

    //public variables
    this.defaultColor = 'black';
    this.pointSize = 6;
    this.fontSize = 16;
    this.font = "Cursive, Courier";

    this.perspective = 150; //perspective


    //private methods
    var setRange = function(startX,endX,startY,endY){
            coef = height / (Math.abs(startY) + Math.abs(endY));

            //TODO: fix for not square canvas
            zeroX = Math.abs(startX)*coef;
            zeroY = Math.abs(endY)*coef;
        },

        //!
        drawAxis = function(xStartP,xEndP,yStartP,yEndP,zStartP,zEndP){

            that.addLine(new Line(xStartP,xEndP), '#d3d3d3');
            that.addLine(new Line(yStartP,yEndP), '#d3d3d3');
            that.addLine(new Line(zStartP,zEndP), '#d3d3d3');

            var step=(Math.abs(xStartP.x) + Math.abs(xEndP.x))*0.05;

            //collect axis points
            for (var i=xStartP.x; i<xEndP.x; i+=step){
                that.addPoint(new Point(i,xStartP.y,xStartP.z), 'black', i.toFixed(1));
            };
            that.addPoint(new Point(i, xEndP.y, xEndP.z), 'black', 'X');

            for (var i=yStartP.y; i<yEndP.y; i+=step){
                that.addPoint(new Point(yStartP.x, i, yStartP.z),'black', i.toFixed(1));
            };
            that.addPoint(new Point(yEndP.x, i, yEndP.z), 'black', 'Y');

            for (var i=zStartP.z; i<zEndP.z; i+=step){
                that.addPoint(new Point(zStartP.x, zStartP.y, i), 'black', i.toFixed(1));
            };
            that.addPoint(new Point(zEndP.x, zEndP.y, i), 'black', "Z");
        },

     
        userToScreen = function(x,y,z){
            var sx,
                sy;

                sx = zeroX + that.perspective * coef * x / z;
                sy = zeroY - that.perspective * coef * y / z;

            return {
                x: sx,
                y: sy
            };
        };

    //public methods
    this.addPoint = function(point,color,text){
        if (color) pointsColor.splice(points.length, 0, color);
        if (text) pointsText.splice(points.length, 0, text);

        points.splice(points.length,0,point);
    };
    this.addLine = function(line,color){
        if (color) linesColor.splice(lines.length, 0, color);
        lines.splice(lines.length,0,line);
    };
    this.addPoly = function(poly,color){
        if (color) polysColor.splice(polys.length, 0, color);
        polys.splice(polys.length,0,line);
    };

    //TODO:remove;

    this.clear = function(){
        context.clearRect ( 0 , 0 , width, height);
    };

    var drawPoints = function(){
            var transf = matrixMultiply(points,transformMatrix),
                current,
                i,
                scr,
                px;

            context.font = that.fontSize + 'px ' + that.font;

            for (i = 0; i < transf.length; i++){
                current = transf[i];
                scr = userToScreen(current[0],current[1],current[2]);
                px = that.pointSize;

                context.fillStyle = pointsColor[i] || that.defaultColor;

                context.fillRect(scr.x-px/2,scr.y-px/2,px,px);
                if (pointsText[i]) context.fillText(pointsText[i],scr.x + 10,scr.y -10);
            }
        },
        drawLines = function(){
            var i,
                current,
                transf = [];

            for (i = 0; i < lines.length; i++){
                current = lines[i];
                transf[0] = current.start;
                transf[1] = current.end;

                transf = matrixMultiply(transf,transformMatrix);
                var scr1 = userToScreen(transf[0][0],transf[0][1],transf[0][2]),
                    scr2 = userToScreen(transf[1][0],transf[1][1],transf[1][2]);

                context.fillStyle = linesColor[i] || that.defaultColor;

                context.beginPath();
                context.moveTo(scr1.x,scr1.y);
                context.lineTo(scr2.x,scr2.y);
                context.stroke();
        }

        },
        drawPolys = function(){

        };

    //draw all
    this.draw = function(){ 
        that.clear();
        drawPoints();
        drawLines();
        drawPolys();
    };

    //3d specific functions

    var matrixMultiply = function (points,matrix){
        var newMatrix = [],
            transf = [],
            rows = points.length,
              cols = matrix[0].length,
            inners = matrix.length;

        //init
        for (var i = 0; i < rows; i ++){
            newMatrix.splice(newMatrix.length+1,0,[]);
            for (var j = 0; j < cols; j ++){
                newMatrix[i].splice(newMatrix[i].length+1,0,[0]);
            }
        }
        for (var i in points){
            transf[i]=[];
            transf[i].splice(transf[i].length,0,points[i].x);
            transf[i].splice(transf[i].length,0,points[i].y);
            transf[i].splice(transf[i].length,0,points[i].z);
            transf[i].splice(transf[i].length,0,1);
        }
        //multiply
        for (var row = 0; row < rows; row++) {
            for (var col = 0; col < cols; col++) {
                for (var inner = 0; inner < inners; inner++){
                    var res = transf[row][inner] * matrix[inner][col];
                    newMatrix[row][col] = parseFloat(newMatrix[row][col])+parseFloat(res);
                }
            }
        }
        return newMatrix;
    },
    toRadians = function (angle) {
        return angle * (Math.PI / 180);
    };


    this.setTransform = function(p, teta, gamma){
        var t = toRadians(teta),
            g = toRadians(gamma),
            sin = Math.sin,
            cos = Math.cos;

        transformMatrix =  [[-sin(t), -cos(g) * cos(t), -sin(g) * cos(t), 1],
                            [cos(t), -cos(g) * sin(t), -sin(g) * sin(t), 1],
                            [0, sin(g), -cos(g), 1],
                            [0, 0, p, 1]];
        that.draw();
    }

    //initialization
    that.clear();
    setRange(startX,endX,startY,endY);
    //drawAxis(xStart,xEnd,yStart,yEnd,zStart,zEnd);
    //that.setRotateHandler();
    that.draw();



    console.log("CanvasPaint initialized.");
}

