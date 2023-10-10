function ChangeImage(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imagePath').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
$("#image").change(function () {
    readURL(this);
});
//////////////////////////////////////////////////

function Delete(id, controller) {

    Swal.fire({
        title: 'Do you want to delete?',
        text: 'After removal, it is moved to the trash',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {




            fetch('/Admin/' + controller + '/Delete/' + id)
                .then(response => response.json())
                .then(data => {
                    if (data === true) {
                        $("#item_" + id).hide('slow');

                        Swal.fire({
                            title: 'The deletion was successful',
                            icon: 'success',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'Ok'

                        });
                    } else {
                        Swal.fire({
                            title: 'An error has occurred',
                            icon: 'error',
                            text: 'Check the logged error log',
                            confirmButtonColor: '#3085d6',

                            confirmButtonText: 'Ok'

                        });
                    }
                })
                .catch(error => {
                    Swal.fire({
                        title: 'Server side error',
                        icon: 'error',
                        text: 'Check the logged error log',
                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'Ok'

                    });
                });



        }
    });
}



function Back(id, controller) {

    Swal.fire({
        title: 'Does it move to the main list?',
        text: 'After confirmation, it will be transferred to the main list',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch('/Admin/' + controller + '/Back/' + id)
                .then(response => response.json())
                .then(data => {
                    if (data === true) {
                        $("#item_" + id).hide('slow');

                        Swal.fire({
                            title: 'Restored successfully',
                            icon: 'success',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'Ok'

                        });
                    } else {
                        Swal.fire({
                            title: 'An error has occurred',
                            icon: 'error',
                            text: 'Check the logged error log',
                            confirmButtonColor: '#3085d6',

                            confirmButtonText: 'Ok'

                        });
                    }
                })
                .catch(error => {
                    Swal.fire({
                        title: 'Server side error',
                        icon: 'error',
                        text: 'Check the logged error log',
                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'Ok'

                    });
                });



        }
    });
}
function Remove(id, controller) {

    Swal.fire({
        title: 'Do you want to remove completely?',
        text: 'Once deleted, it cannot be restored',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {




            fetch('/Admin/' + controller + '/Remove/' + id)
                .then(response => response.json())
                .then(data => {
                    if (data === true) {
                        $("#item_" + id).hide('slow');

                        Swal.fire({
                            title: 'The final deletion was successful',
                            icon: 'success',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'Ok'

                        });
                    } else {
                        Swal.fire({
                            title: 'An error has occurred',
                            icon: 'error',
                            text: 'Check the logged error log',
                            confirmButtonColor: '#3085d6',

                            confirmButtonText: 'Ok'

                        });
                    }
                })
                .catch(error => {
                    Swal.fire({
                        title: 'Server side error',
                        icon: 'error',
                        text: 'Check the logged error log',
                        confirmButtonColor: '#3085d6',

                        confirmButtonText: 'Ok'

                    });
                });

        }
    });
}


function closeAlert() {

    $("#closeAlert").hide('slow');
}