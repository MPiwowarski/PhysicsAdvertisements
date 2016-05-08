$(function () {
    $(".datepicker").datepicker({
        dateFormat: "mm-dd-yy",
        beforeShow: function (input, inst) {
            // Handle calendar position before showing it.
            // It's not supported by Datepicker itself (for now) so we need to use its internal variables.
            var calendar = inst.dpDiv;

            // Dirty hack, but we can't do anything without it (for now, in jQuery UI 1.8.20)
            setTimeout(function () {
                calendar.position({
                    my: 'right top',
                    at: 'right bottom',
                    collision: 'none',
                    of: input
                });
            }, 1);
        }
    });

});