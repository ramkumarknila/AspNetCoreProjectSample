//Date Picker
$('.past-date').datepicker({
    format: "dd/mm/yyyy",
    autoclose: true,
    todayHighlight: true,
    buttonImage: "images/calendar.gif",
    minDate:0,
    maxDate: function () {
        var date = new Date();
        date.setDate(date.getDate() - 1);
        return new Date(date.getFullYear(), date.getMonth(), date.getDate());
    }
});

$('.feature-date').datepicker({
    format: "dd/mm/yyyy",
    autoclose: true,
    todayHighlight: true,
    minDate: 'today',
    maxDate: 0
});

$('.default-date').datepicker({
    format: "dd/mm/yyyy",
    autoclose: true,
    todayHighlight: true
});

//Multi select dropdown
$('.multi-select').select2();