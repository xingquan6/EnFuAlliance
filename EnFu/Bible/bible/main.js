$(document).ready(function () {
	$('p').on('click', function () {
		if ($(this).css('font-weight') == 600) {
			$(this).attr("style", "font-weight:normal;background:white;border: 1px solid gray; margin:5px auto;padding:10px;");
            } else {
            $(this).attr("style", "font-weight:600;background:#F4F4F4;border: 1px solid gray; margin:5px auto;padding:10px;");
        }
    });
});