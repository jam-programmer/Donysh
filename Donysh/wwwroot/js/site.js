
var currentSlide = 0;
var slides = document.querySelectorAll('.slide');

function showSlide(index) {
    slides.forEach((slide, i) => {
        if (i === index) {
            slide.style.display = 'block';
        } else {
            slide.style.display = 'none';
        }
    });
}

function nextSlide() {
    currentSlide = (currentSlide + 1) % slides.length;
    showSlide(currentSlide);
}

// Call nextSlide function every 3 seconds
setInterval(nextSlide, 3000);


async function Request() {
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var email = document.getElementById("email").value;
    var detail = document.getElementById("detail").value;
    if (!firstName) {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "The first name cannot be empty",
            showConfirmButton: false,
            timer: 1500
        });
        return;
    }
    if (!lastName) {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "The last name cannot be empty",
            showConfirmButton: false,
            timer: 1500
        });
        return;
    }
    if (!email) {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "The email cannot be empty",
            showConfirmButton: false,
            timer: 1500
        });
        return;
    }
    if (!detail) {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "The detail cannot be empty",
            showConfirmButton: false,
            timer: 1500
        });
        return;
    }
    var checkboxes = document.getElementsByName('service');

    var checkedCheckboxes = [];


    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            checkedCheckboxes.push(checkboxes[i].value);

        }
    }
    var request = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        Description: detail,
        services: checkedCheckboxes
    };

    fetch('/Home/ReceiveRequestInfo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    })
        .then(response => response.json())
        .then(data => {

            if (data) {
                var checkboxes = document.getElementsByName('service');
                for (var i = 0; i < checkboxes.length; i++) {
                    checkboxes[i].checked = false;
                }
                document.getElementById("firstName").value = "";
                document.getElementById("lastName").value = "";
                document.getElementById("email").value = "";
                document.getElementById("detail").value = "";
                Swal.fire({
                    position: "center",
                    icon: "success",
                    title: "Thank you for your message",
                    showConfirmButton: false,
                    timer: 1500
                });
              



            } else {
               

                    
                    Swal.fire({
                        position: "center",
                        icon: "warning",
                        title: "The request was not registered",
                        showConfirmButton: false,
                        timer: 1500
                    });
            }

        })
        .catch(error => {
           


            Swal.fire({
                position: "center",
                icon: "Error",
                title: "A system error has occurred. Please try again later",
                showConfirmButton: false,
                timer: 1500
            });
        });
}


async function ContactRequest() {
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var subject = document.getElementById("subject").value;
    var comment = document.getElementById("comment").value;


    if (!email) {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "The email cannot be empty",
            showConfirmButton: false,
            timer: 1500
        });
        return;
    }
    if (!subject) {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "The subject be empty",
            showConfirmButton: false,
            timer: 1500
        });
        return;
    }
    var request = {
        FullName: name,
        Email: email,
        Subject: subject,
        Description: comment
    };



    fetch('/Home/ContactRequest', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        })
        .then(response => response.json())
        .then(data => {

            if (data) {
                
                document.getElementById("name").value = "";
                document.getElementById("subject").value = "";
                document.getElementById("email").value = "";
                document.getElementById("comment").value = "";
                Swal.fire({
                    position: "center",
                    icon: "success",
                    title: "Thank you for your message",
                    showConfirmButton: false,
                    timer: 1500
                });




            } else {



                Swal.fire({
                    position: "center",
                    icon: "warning",
                    title: "The request was not registered",
                    showConfirmButton: false,
                    timer: 1500
                });
            }

        })
        .catch(error => {



            Swal.fire({
                position: "center",
                icon: "Error",
                title: "A system error has occurred. Please try again later",
                showConfirmButton: false,
                timer: 1500
            });
        });



}