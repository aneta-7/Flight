function validateTime(time) {
    if (!time) {
        return false;
    }
    var military = /^\s*([01]?\d|2[0-3]):[0-5]\d\s*$/i;
    var standard = /^\s*(0?\d|1[0-2]):[0-5]\d(\s+(AM|PM))?\s*$/i;
    return time.test(military) || time.test(standard);
}

$(new function () {
    $('.required').on('blur', function () {
        if (!validateTime($(this).val())) {
            $(this).val('12:00 AM');
            $(this).keyup();
        }
    });
    $('.warnIfInvalid').on('keyup', function () {
        $(this).css('color', 'black');
        if (!validateTime($(this).val())) {
            $(this).css('color', 'red');
        }
    });
});
