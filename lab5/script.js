document.addEventListener('contextmenu', function(e) {
      e.preventDefault();
    }, false);

    var draw = function() {

      var c   = document.getElementById("myCanvas"),
          ctx = c.getContext("2d");
      var size = {
        width:  800,
        height: 600
      };
      var halfSize = {
        x: size.width / 2,
        y: size.height / 2,
        z: (size.width + size.height) / 4,
      }
      var input = {
        theta: 0,
        phi:   0,
        rho:   1200,
        d:     400,
        light: {
          point: {
            x: 0,
            y: -400,
            z: -500
          },
          size: 100
        }
      };
      var vertices0 = [
    	0, 0, 0,
		0, 300, 0,
		300, 300, 0,
		300, 0, 0,
		0, 0, 300,
		0, 300, 300,
		300, 300, 300,
		300, 0, 300
      ];
      var cube = [
        0, 1, 2, 3, //back
        4, 5, 6, 7, //front
        0, 1, 5, 4, //left
        3, 2, 6, 7, //right
        1, 5, 6, 2, //top
        0, 4, 7, 3 //bottom
      ];
      var vertices1 = [
        100, 100, 100,
		100, 400, 100,
		400, 400, 100,
		400, 100, 100,
		100, 100, 400,
		100, 400, 400,
		400, 400, 400,
		400, 100, 400
      ];
      var cube2 = [
        0, 1, 2, 3, //back
        4, 5, 6, 7, //front
        0, 1, 5, 4, //left
        3, 2, 6, 7, //right
        1, 5, 6, 2, //top
        0, 4, 7, 3 //bottom
      ];
      var vertices2 = [
        input.light.point.x, input.light.point.y, input.light.point.z, // 0
        input.light.point.x, input.light.point.y + input.light.size, input.light.point.z + input.light.size, // 1
        input.light.point.x + input.light.size, input.light.point.y + input.light.size, input.light.point.z + input.light.size, // 2
        input.light.point.x + input.light.size, input.light.point.y, input.light.point.z, // 3
        input.light.point.x + input.light.size, input.light.point.y, input.light.point.z, // 4
        input.light.point.x + input.light.size, input.light.point.y + input.light.size, input.light.point.z + input.light.size, // 5
        input.light.point.x, input.light.point.y + input.light.size, input.light.point.z + input.light.size, // 6
        input.light.point.x, input.light.point.y, input.light.point.z  // 7
      ];
      var L = [
        0, 1, 2, 3, //back
        4, 5, 6, 7, //front
        0, 1, 5, 4, //left
        3, 2, 6, 7, //right
        1, 5, 6, 2, //top
        0, 4, 7, 3 //bottom
      ];
      var V;

      var calcV = function() {
        return [
          [
            -Math.sin(input.phi),
            -Math.cos(input.theta) * Math.cos(input.phi),
            -Math.sin(input.theta) * Math.cos(input.phi),
            0
          ],
          [
            Math.cos(input.phi),
            -Math.cos(input.theta) * Math.sin(input.phi),
            -Math.sin(input.theta) * Math.sin(input.phi),
            0
          ],
          [
            0,
            Math.sin(input.theta),
            -Math.cos(input.theta),
            0
          ],
          [ 0, 0, input.rho, 1 ]
        ];
      };

      var initMatrix = function(rows, cols, vals) {
        var val = 0;
        if(vals) {
          val = vals;
        }
        var ret = [ ];
        for(var i = 0; i < rows; i++) {
          var tmp = [ ];
          for(var j = 0; j < cols; j++) {
            tmp.push(val);
          }
          ret.push(tmp);
        }
        return ret;
      };

      var matrixProduct = function(m1, m2) {
        var res = initMatrix(m1.length, m2[0].length, 0);
        for(var i = 0; i < m1.length; i++) {
          for(var j = 0; j < m2[0].length; j++) {
            for(var k = 0; k < m1[0].length; k++) {
              res[i][j] += m1[i][k] * m2[k][j];
            }
          }
        }
        return res;
      };

      var zFill = function(n, l) {
        return (l > n.toString().length) ? ((Array(l).join('0') + n).slice(-l)) : n;
      };

      var rgb2hex = function(rgb) {
        //var color = rgb.r + 256 * rgb.g + 256 * 256 * rgb.b;
        var color = 256 * 256 * rgb.r + 256 * rgb.g + rgb.b;
        return zFill(color.toString(16), 6);
      };

      var hex2rgb = function(hex) {
        hex = "0x" + hex;
        var ret = { };
        ret.r = hex >> 16;
        ret.g = hex >> 8 & 0xFF;
        ret.b = hex & 0xFF;
        return ret;
      };

      var FAR_Z   = -100000,
          zBuffer,
          pixels;

      var clear = function() {
        zBuffer = initMatrix(size.width, size.height, FAR_Z);
        pixels  = initMatrix(size.width, size.height, rgb2hex({ r: 240, g: 240, b: 240 }));
      };

      clear();

      /*var getMinPoint = function() {
        var buf = vertices0.concat(vertices1);
        var min = {
          x: buf[0],
          y: buf[1],
          z: buf[2]
        };
        for(var i = 3; i < buf.length; i++) {
          if(((i % 3) == 0) && buf[i] < min.x) {
            min.x = buf[i];
          }
          else if(((i % 3) == 1) && buf[i] < min.y) {
            min.y = buf[i];
          }
          else if(((i % 3) == 2) && buf[i] < min.z) {
            min.z = buf[i];
          }
        }
        return min;
      };

      var getMaxPoint = function() {
        var buf = vertices0.concat(vertices1);
        var max = {
          x: buf[0],
          y: buf[1],
          z: buf[2]
        };
        for(var i = 3; i < buf.length; i++) {
          if(((i % 3) == 0) && buf[i] > max.x) {
            max.x = buf[i];
          }
          else if(((i % 3) == 1) && buf[i] > max.y) {
            max.y = buf[i];
          }
          else if(((i % 3) == 2) && buf[i] > max.z) {
            max.z = buf[i];
          }
        }
        return max;
      };

      var getCenterPoint = function() {
        var buf = vertices0.concat(vertices1),
            min = getMinPoint(),
            max = getMaxPoint();
        return {
          x: (max.x + min.x) / 2,
          y: (max.y + min.y) / 2,
          z: (max.z + min.z) / 2
        };
      };

      var center = getCenterPoint();*/

      var getCubePoint = function(idx) {
        return [[
          vertices0[cube[idx] * 3 + 0] - halfSize.x,
          vertices0[cube[idx] * 3 + 1] - halfSize.y,
          vertices0[cube[idx] * 3 + 2] - halfSize.z,
          1
        ]];
      };

      var getCube2Point = function(idx) {
        return [[
          vertices1[cube2[idx] * 3 + 0] - halfSize.x,
          vertices1[cube2[idx] * 3 + 1] - halfSize.y,
          vertices1[cube2[idx] * 3 + 2] - halfSize.z,
          1
        ]];
      };

      var getLightPoint = function(idx) {
        return [[
          vertices2[L[idx] * 3 + 0] - halfSize.x,
          vertices2[L[idx] * 3 + 1] - halfSize.y,
          vertices2[L[idx] * 3 + 2] - halfSize.z,
          1
        ]];
      };

      var getPoint2 = function(p3) {
        var p2 = {
          x: p3[0][0] * (input.d / p3[0][2]),
          y: p3[0][1] * (input.d / p3[0][2]),
          z: p3[0][2]
        };
        p2.x = halfSize.x + p2.x;
        p2.y = halfSize.y + p2.y;
        return p2;
      };

      var drawPoint = function(p) {
        ctx.fillRect(p.x, p.y, 3, 3);
        ctx.fillText(Math.round(p.x) + '; ' + Math.round(p.y), p.x, p.y);
      };

      /*var getPlaneEq = function(plane) {
        var ret = { };
        ret.A = (plane[1].y - plane[0].y) * (plane[2].z - plane[0].z) - (plane[1].z - plane[0].z) * (plane[2].y - plane[0].y),
        ret.B = (-1) * (plane[1].x - plane[0].x) * (plane[2].z - plane[0].z) - (plane[1].z - plane[0].z) * (plane[2].x - plane[0].x),
        ret.C = (plane[1].x - plane[0].x) * (plane[2].y - plane[0].y) - (plane[1].y - plane[0].y) * (plane[2].x - plane[0].x),
        ret.D = (-1) * ret.A * plane[0].x - ret.B * plane[0].y - ret.C * plane[0].z;
        if(ret.C == 0) {
          console.log("Error... getPlaneEq C == 0.");
        }
        return ret;
      };*/

      /*var getZ = function(planeEq) {
        return (-1) * planeEq.A / planeEq.C;
      };*/

      var getZ = function(a, b, x) {
        return pz = a.z + (b.z - a.z) * (x - a.x) / (b.x - a.x);
      };

      /*var getDeltaZ = function(planeEq, start) {
        return (-1) * (planeEq.A * start.x + planeEq.B * start.y + planeEq.D) / planeEq.C;
      };*/
      
      var getActiveEdges = function(edges, index, y) {
        var ret = { index: index, activeEdges: [ ] };
        for(var i = index; i < edges.length; i++) {
          if(edges[i].start.y == y) {
            ret.activeEdges.push(edges[i]);
            ret.index = i;
          }
          else {
            break;
          }
        }
        ret.index++;
        return ret;
      };

      var getCrossPoints = function(y, activeEdges) {
        var crossPoints = [ ];
        for(var i in activeEdges) {
          if(activeEdges[i]) {
            var m1 = y - activeEdges[i].start.y,
                m2 = activeEdges[i].end.x - activeEdges[i].start.x,
                m3 = activeEdges[i].end.z - activeEdges[i].start.z,
                d  = activeEdges[i].end.y - activeEdges[i].start.y,
                x  = (m1 * m2) / d + activeEdges[i].start.x,
                z  = (m1 * m3) / d + activeEdges[i].start.z,
                i1 = activeEdges[i].start.i * (y - activeEdges[i].end.y),
                i2 = activeEdges[i].end.i * (activeEdges[i].start.y - y),
                id = activeEdges[i].start.y - activeEdges[i].end.y,
                i  = (i1 + i2) / id;
            crossPoints.push({
              x: x,
              z: z,
              i: i
            });
          }
        }
        crossPoints.sort(function(lhs, rhs) {
          return (+rhs) - (+lhs);
        });
        return crossPoints;
      };

      var roundPoint = function(p) {
        var ret = p;
        ret.x = Math.round(ret.x);
        ret.y = Math.round(ret.y);
        ret.z = Math.round(ret.z);
        return ret;
      };

      var fill = function(plane, color) {
        var edges = [ ];
        for(var i = 0; i < plane.length - 1; i++) {
          edges.push({
            start: roundPoint(plane[i]),
            end:   roundPoint(plane[i + 1])
          });
        }
        edges.push({
          start: roundPoint(plane[plane.length - 1]),
          end:   roundPoint(plane[0])
        });
        //console.log(edges);
        var minY = edges[0].start.y,
            maxY = edges[edges.length - 1].end.y
        edges.forEach(function(e) {
          if(e.start.y > e.end.y) {
            var buf = e.start;
            e.start = e.end;
            e.end = buf;
          }
          if(e.start.y > maxY) {
            maxY = e.start.y;
          }
          if(e.end.y > maxY) {
            maxY = e.end.y;
          }
          if(e.start.y < minY) {
            minY = e.start.y;
          }
          if(e.end.y < minY) {
            minY = e.end.y;
          }
        });
        edges.sort(function(lhs, rhs) {
          return (+lhs.start.y) - (+rhs.start.y);
        });
        var activeEdges = getActiveEdges(edges, 0, minY),
            index = activeEdges.index/*,
            planeEq = getPlaneEq(plane)*/;
        activeEdges = activeEdges.activeEdges;
        for(var y = minY; y < maxY; y++) {

          for(; index < edges.length; ++index) {
            if(edges[index].start.y === y) {
              activeEdges.push(edges[index]);
            }
            else {
              break;
            }
          }

          for(var i in activeEdges) {
            if(activeEdges[i].end.y == y) {
              if(activeEdges[i]) {
                delete activeEdges[i];
              }
            }
          }

          var crossPoints = getCrossPoints(y, activeEdges);
          crossPoints = crossPoints.sort(function(lhs, rhs) {
            return (+lhs.x) - (+rhs.x);
          });
          for(var idx = 0; idx < crossPoints.length - 1; idx++) {
            var a = crossPoints[idx],
                b = crossPoints[idx + 1],
                s = Math.round(a.x),
                e = Math.round(b.x),
                d = (b.i - a.i) / (e - s),
                rgb = hex2rgb(color);
            for(var x = s, intens = a.i; x < e; x++, intens += d) {
              var z = getZ(a, b, x);
              if(z > zBuffer[x][y]) {
                zBuffer[x][y] = z;
                /*if(color = "F0AD4E") {
                  console.log("intens", intens);
                }*/
                 pixels[x][y]  = rgb2hex({ 
                   r: Math.round(rgb.r * (1 - intens)), 
                   g: Math.round(rgb.g * (1 - intens)), 
                   b: Math.round(rgb.b * (1 - intens)) 
                }); 
				/*pixels[x][y] = rgb2hex({
					r: Math.round(rgb.r),
					g: Math.round(rgb.g),
					b: Math.round(rgb.b),
				});*/
              }
            }
          }
        }

      };

      var zBufer = function(obj, color) {
        for(var o in obj) {
          fill(obj[o], color);
        }
      };

      var getLightCenterPoint = function(light) {
        var min = {
          x: light[0][0].x,
          y: light[0][0].y,
          z: light[0][0].z
        };
        var max = {
          x: light[0][0].x,
          y: light[0][0].y,
          z: light[0][0].z
        };
        for(var i in light) {
          for(var j in light[i]) {

            if(light[i][j].x < min.x) {
              min.x = light[i][j].x;
            }
            else if(light[i][j].x > max.x) {
              max.x = light[i][j].x;
            }

            if(light[i][j].y < min.y) {
              min.y = light[i][j].y;
            }
            else if(light[i][j].y > max.y) {
              max.y = light[i][j].y;
            }

            if(light[i][j].z < min.z) {
              min.z = light[i][j].z;
            }
            else if(light[i][j].z > max.z) {
              max.z = light[i][j].z;
            }

          }
        }
        return {
          x: (min.x + max.x) / 2,
          y: (min.y + max.y) / 2,
          z: (min.z + max.z) / 2
        };
      };

      var getDistance = function(p1, p2) {
        return Math.sqrt(
          Math.pow(p1.x - p2.x, 2) + 
          Math.pow(p1.y - p2.y, 2) + 
          Math.pow(p1.z - p2.z, 2)
        );
      };

      var redraw = function() {
        clear();
        V = calcV();
        var VL = [
        	[1, 1, 0, 0],
        	[1, 0, 0, 1],
        	[-1, -1, -1, -1],
        	[5, 5, 900, 1]
        ];
        ctx.clearRect(0, 0, size.width, size.height);
        var objects = {
          cube: [ ],
          cube2: [ ],
          light: [ ]
        };

        for(var i = 0; i < L.length; i += 4) {
          var pt0 = matrixProduct(getLightPoint(i), VL);
          var pt1 = matrixProduct(getLightPoint(i + 1), VL);
          var pt2 = matrixProduct(getLightPoint(i + 2), VL);
          var pt3 = matrixProduct(getLightPoint(i + 3), VL);

          var p0 = getPoint2(pt0);
          var p1 = getPoint2(pt1);
          var p2 = getPoint2(pt2);
          var p3 = getPoint2(pt3);
          p0.i = 0;
          p1.i = 0;
          p2.i = 0;
          p3.i = 0;
          objects.light.push([ p0, p1, p2, p3 ]);
        }
        var l = getLightCenterPoint(objects.light);

        var nm = 0;
        for(var i = 0; i < cube.length; i += 4) {
          var pt0 = matrixProduct(getCubePoint(i), V);
          var pt1 = matrixProduct(getCubePoint(i + 1), V);
          var pt2 = matrixProduct(getCubePoint(i + 2), V);
          var pt3 = matrixProduct(getCubePoint(i + 3), V);

          var p0 = getPoint2(pt0);
          var p1 = getPoint2(pt1);
          var p2 = getPoint2(pt2);
          var p3 = getPoint2(pt3);
          p0.i = getDistance(p0, l);
          p1.i = getDistance(p1, l);
          p2.i = getDistance(p2, l);
          p3.i = getDistance(p3, l);
          if(p0.i > nm) { nm = p0.i; }
          if(p1.i > nm) { nm = p1.i; }
          if(p2.i > nm) { nm = p2.i; }
          if(p3.i > nm) { nm = p3.i; }
          objects.cube.push([ p0, p1, p2, p3 ]);
        }
        for(var i in objects.cube) {
          for(var j in objects.cube[i]) {
            objects.cube[i][j].i /= nm;
          }
        }

        var nm = 0;
        for(var i = 0; i < cube2.length; i += 4) {
          var pt0 = matrixProduct(getCube2Point(i), V);
          var pt1 = matrixProduct(getCube2Point(i + 1), V);
          var pt2 = matrixProduct(getCube2Point(i + 2), V);
          var pt3 = matrixProduct(getCube2Point(i + 3), V);

          var p0 = getPoint2(pt0);
          var p1 = getPoint2(pt1);
          var p2 = getPoint2(pt2);
          var p3 = getPoint2(pt3);
          p0.i = getDistance(p0, l);
          p1.i = getDistance(p1, l);
          p2.i = getDistance(p2, l);
          p3.i = getDistance(p3, l);
          if(p0.i > nm) { nm = p0.i; }
          if(p1.i > nm) { nm = p1.i; }
          if(p2.i > nm) { nm = p2.i; }
          if(p3.i > nm) { nm = p3.i; }
          objects.cube2.push([ p0, p1, p2, p3 ]);
        }
        for(var i in objects.cube2) {
          for(var j in objects.cube2[i]) {
            objects.cube2[i][j].i /= nm;
          }
        }

        zBufer(objects.cube2, "ff0000");
        zBufer(objects.cube, "00ff00");
        // zBufer(objects.light, "0000ff");

        for(var w in pixels) {
          for(var h in pixels[w]) {
            ctx.beginPath();
            ctx.fillStyle   = "#" + pixels[w][h];
            ctx.fillRect(w, h, 1, 1);
          }
        }

        /*ctx.strokeStyle = "#FF0000";
        for(var o in objects) {
          if(o == "light") {
            continue;
          }
          for(var f in objects[o]) {
            for(var p = 0; p < objects[o][f].length - 1; p++) {
              var c = objects[o][f][p],
                  n = objects[o][f][p + 1];
              ctx.moveTo(c.x, c.y);
              ctx.lineTo(n.x, n.y);
            }
            var c = objects[o][f][objects[o][f].length - 1],
                n = objects[o][f][0];
            ctx.moveTo(c.x, c.y);
            ctx.lineTo(n.x, n.y);
          }
        }*/
        ctx.stroke();

        document.getElementById("theta-value").innerHTML = input.theta;
        document.getElementById("phi-value").innerHTML = input.phi;
        document.getElementById("rho-value").innerHTML = input.rho;
        document.getElementById("d-value").innerHTML = input.d;
      };

      redraw();
      document.getElementById("theta").value = input.theta;
      document.getElementById("phi").value = input.phi;
      document.getElementById("rho").value = input.rho;
      document.getElementById("d").value = input.d;

       document.getElementById("theta").addEventListener("mousemove", function(e) {
        if(input.theta != this.value) {
          input.theta = this.value;
          redraw();
        }
      }, false);
      document.getElementById("phi").addEventListener("mousemove", function(e) {
        if(input.phi != this.value) {
          input.phi = this.value;
          redraw();
        }
      }, false);
      document.getElementById("rho").addEventListener("mousemove", function(e) {
        if(input.rho != this.value) {
          input.rho = this.value;
          redraw();
        }
      }, false);
      document.getElementById("d").addEventListener("mousemove", function(e) {
        if(input.d != this.value) {
          input.d = this.value;
          redraw();
        }
      }, false);
	  document.getElementById("drawButton").addEventListener("onclick", function(e)
	  {
		input.theta = document.getElementById("theta").value;
		input.phi = document.getElementById("phi").value;		
		input.rho = document.getElementById("rho").value;		
		input.d = document.getElementById("d").value;
		redraw();		
	  }, false);
    };