$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('#dateOfBirth').on('change', function () {
        debugger
        var selectedDate = new Date($(this).val());
        var today = new Date();
        today.setHours(0, 0, 0, 0); // Set time to midnight for accurate comparison

        if (selectedDate <= today) {
            $('#dateError').show();
            $(this).val(''); // Clear the input
        } else {
            $('#dateError').hide();
        }
    })
    let employeeId;

    $('.del-btn').click(function () {
        
        employeeId = $(this).data('id');
        $('#confirm-delete').modal('show');
    });

    $('#confirm-btn').click(function () {
        $.post('/Home/Deleteemployee', { id: employeeId }, function () {
            location.reload();
        });
    });

    $('#cancel-btn').click(function () {
        $('#confirm-delete').hide();
    });
})