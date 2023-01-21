$(document).ready(function () {
    // use the jquery UI datepicker:
    $('input[type=datetime]').datepicker({
        dateFormat: 'yy/mm/dd',
        changeMonth: true,
        changeYear: true,
        yearRange: 'today:+3'
    });
});