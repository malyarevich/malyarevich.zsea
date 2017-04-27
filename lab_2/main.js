'use strict';
(function () {
  var canvas = document.getElementById('canvas'),
    ctx = canvas.getContext('2d'),
    startButton = document.getElementById('start'),
    clearButton = document.getElementById('clear'),
    fillColor = 'red',
    points = [];

  function drawPoint(x, y) {
    ctx.fillStyle = fillColor;
    ctx.fillRect(x, y, 1, 1);
  }
  function straightMake(p1, p2) {
    var straight,
      x1 = p1.x,
      x2 = p2.x,
      y1 = p1.y,
      y2 = p2.y,

      a = y1 - y2,
      b = x2 - x1,
      c = x1 * y2 - x2 * y1;

    straight = {
      'a' : a,
      'b': b,
      'c' : c
    };
    return straight;
  }
  function findCross(s1, s2) {
    var a1 = s1.a,
      a2 = s2.a,
      b1 = s1.b,
      b2 = s2.b,
      c1 = s1.c,
      c2 = s2.c,
      x,
      y;

    x = -(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
    y = -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
    return {
      'x' : x,
      'y' : y
    };
  }
  function findCrosses(straights, straight) {
    var crosses = [],
      cross,
      i;
    //find crosses
    for (i = 0; i < straights.length; i++) {
      cross = findCross(straights[i], straight);
      crosses.splice(crosses.length, 0, cross);
    }

    return crosses;
  }
  function findActiveStraights(points, x1, x2, y) {
    var straights = [],
      p1,
      p2,
      straight,
      i,
      x1in,
      x2in,
      yin,
      inside = function (x, x1, x2) {
        return (x <= x1 && x >= x2) || (x <= x2 && x >= x1);
      };

    for (i = 0; i < points.length; i++) {
      p1 = points[i];
      p2 = points[i + 1] || points[0];

      x1in = inside(p1.x, x1, x2);
      x2in = (inside(p2.x, x1, x2));
      yin = inside(y, p1.y, p2.y);

      if (x1in && x2in && yin) {
        straight = straightMake(p1, p2);
        straights.splice(straights.length, 0, straight);
      }
    }
    return straights;
  }
  function findActiveRect(points) {
    var x1 = points[0].x,
      x2 = points[0].x,
      y1 = points[0].y,
      y2 = points[0].y,
      i;

    for (i = 0; i < points.length; i++) {
      if (points[i].x < x1) { x1 = points[i].x; }
      if (points[i].x > x2) { x2 = points[i].x; }
      if (points[i].y < y1) { y1 = points[i].y; }
      if (points[i].y > y2) { y2 = points[i].y; }
    }
    return {
      'x1' : x1,
      'x2' : x2,
      'y1' : y1,
      'y2' : y2
    };
  }

  function draw() {
    var rect = findActiveRect(points),
	  lineRange,
      crosses,
      activeStraights,
      p1,
      p2,
      x,
      y,
      i,
      j;
	  

    // algorythm start
    for (i = rect.y1; i < rect.y2; i++) {// rect.y2; i++) {
      p1 = {
        'x' : rect.x1,
        'y' : i
      };
      p2 = {
        'x' : rect.x2,
        'y' : i
      };
      activeStraights = findActiveStraights(points, rect.x1, rect.x2, i);
      crosses = findCrosses(activeStraights, straightMake(p1, p2));

      if (crosses.length > 0) {
        x = crosses[0].x;
      y = crosses[0].y;
      ctx.beginPath();
      ctx.moveTo(x, y);
      for (j = 0; j < crosses.length; j++) {
        x = crosses[j].x;
        y = crosses[j].y;
        if (j % 2 === 0) {
          ctx.moveTo(x, y);
        } else {
          ctx.lineTo(x, y);
        }
      }
      ctx.stroke();
      }
    }
  }
  function addPoint(x, y) {
    drawPoint(x, y);
    points.splice(points.length, 0, {'x' : x, 'y' : y});
  }
  function clear() {
    points = [];
    ctx.clearRect(0, 0, canvas.width, canvas.height);
  }
  canvas.onclick = function (e) {
    var x = 0,
      y = 0;
    //get click point
    if (e.pageX || e.pageY) {
      x = e.pageX;
      y = e.pageY;
    } else {
      x = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
      y = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
    }
    x -= canvas.offsetLeft;
    y -= canvas.offsetTop;

    //collect click point
    addPoint(x, y);
  };

  startButton.onclick = draw;
  clearButton.onclick = clear;
}());
