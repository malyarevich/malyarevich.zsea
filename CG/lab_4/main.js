(function () {
	var paint = new canvasPaint('canvas', -10, 10, -10, 10, -10, 10),
		l = 5,
		points = [
			new Point(0 - l / 2, 0 - l / 2, l - l / 2),
			new Point(0 - l / 2, l - l / 2, 0 - l / 2),
			new Point(l - l / 2, 0 - l / 2, 0 - l / 2),
			new Point(0 - l / 2, l - l / 2, l - l / 2),
			new Point(l - l / 2, 0 - l / 2, l - l / 2),
			new Point(l - l / 2, l - l / 2, 0 - l / 2),
			new Point(l - l / 2, l - l / 2, l - l / 2),
			new Point(0 - l / 2, 0 - l / 2, 0 - l / 2)
		],
		p_ = document.getElementById("p"),
		gamma = document.getElementById("gamma"),
		teta = document.getElementById("teta"),
		/*pers = document.getElementById("perspective"),
		pers_v =  document.getElementById("perspective_val"),*/
		p_val = document.getElementById("p_val"),
		teta_val = document.getElementById("teta_val"),
		gamma_val = document.getElementById("gamma_val"),
		p = 0,
		g = 0,
		t = 0;


	paint.addLine(new Line(points[0], points[3]));
	paint.addLine(new Line(points[0], points[4]));
	paint.addLine(new Line(points[0], points[7]));
	paint.addLine(new Line(points[7], points[2]));
	paint.addLine(new Line(points[7], points[1]));
	paint.addLine(new Line(points[1], points[3]));
	paint.addLine(new Line(points[1], points[5]));
	paint.addLine(new Line(points[5], points[6]));
	paint.addLine(new Line(points[5], points[2]));
	paint.addLine(new Line(points[6], points[3]));
	paint.addLine(new Line(points[6], points[4]));
	paint.addLine(new Line(points[4], points[2]));

	paint.draw();
	paint.setTransform(50, 0, 0);

	p_.oninput = function() {
		p = parseInt(p_.value);
		p_val.innerText = p;
		paint.setTransform(p, t, g);
	};
	gamma.oninput = function() {
		g = parseInt(gamma.value);
		gamma_val.innerText = g;
		paint.setTransform(p, t, g);
	};
	teta.oninput = function() {
		t = parseInt(teta.value);
		teta_val.innerText = t;
		paint.setTransform(p, t, g);
	};
	pers.oninput = function() {
		var perspective = parseInt(pers.value);
		pers_v.innerText = perspective;
		paint.perspective = perspective;
		paint.draw();
	};

}());