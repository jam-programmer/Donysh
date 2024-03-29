
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





function SendFeedback() {

    var fullName = document.getElementById("fullName");
    var companyName = document.getElementById("companyName");
    var email = document.getElementById("email");
    var description = document.getElementById("description");
    var file = document.getElementById("file");


    if (fullName.value === "" || companyName.value === "" || email.value === "") {
        Swal.fire({
            position: "center",
            icon: "warning",
            title: "Email, company name is required",
            showConfirmButton: false,
            timer: 1500
        });
        return;

    }

    var formData = new FormData();
    formData.append('FilePath', file.files[0]);
    formData.append('Description', description.value);
    formData.append('EmailAddress', email.value);
    formData.append('CompanyName', companyName.value);
    formData.append('FullName', fullName.value);


    try {

        Swal.fire({
            title: " Information processing ",
            html: "Please wait",
            timer: 5000,
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
            willClose: () => {
                clearInterval(timerInterval);
            }
        }).then((result) => {
            if (result.dismiss === Swal.DismissReason.timer) {
                console.log("I was closed by the timer");
            }
        });

        fetch('/RequestFeedback', {

            method: 'POST',
            body: formData,



            headers: {
                'enctype': 'multipart/form-data'
            }

        })
            .then(response => response.json())
            .then(data => {

                if (data) {

                    Swal.fire({
                        position: "center",
                        icon: "success",
                        title: "Thank you for your feedback",
                        showConfirmButton: false,
                        timer: 1500
                    });
                    $('#exampleModalCenter').modal('hide');



                    fullName.value = "";
                    companyName.value = "";
                    email.value = "";
                    description.value = "";
                    file.value = "";

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
    } catch (error) {
        console.log('error', 'خطا: ' + error);
    }
}


function PdfAppend(id) {

    var pdfList = getCache("PdfCache");
    var list = [];
    var project = document.getElementById(id);
    var value = project.getAttribute('data-pdf');
    if (value === "false") {
        project.setAttribute('data-pdf', 'true');
        project.style.backgroundColor = "green";


        if (pdfList) {
            ClearCache("PdfCache");
            var obg1= {
                id:id
            }
            pdfList.push(obg1);
            setCache("PdfCache", pdfList);
            return;
        } else {
            var obg2 = {
                id: id
            }
            list.push(obg2);
            setCache("PdfCache", list); return;
        }


    } else {
        project.setAttribute('data-pdf', 'false');
        project.style.backgroundColor = "red";

        if (pdfList) {
            {

              let index = pdfList.findIndex(item => item.id === id);  
              
                if (index > -1) {
                    pdfList.splice(index, 1); ClearCache("PdfCache");
                    setCache("PdfCache", pdfList);
                } return;
            }
        }
    }
}

function GeneratePdf(image) {
    debugger;
    var pdfList = getCache("PdfCache");
    if (pdfList && pdfList.length>0) {
        try {

            var model = {
                request:  pdfList, Image: image
            };

            fetch('/ExportSelectedProjects', {
                    method: 'POST',
                body: JSON.stringify(model),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(response => response.blob())
                .then(blob => {
                    const url = window.URL.createObjectURL(new Blob([blob]));
                    const a = document.createElement('a');
                    a.style.display = 'none';
                    a.href = url;
                    a.download = 'DonyshProjects.pdf';
                    document.body.appendChild(a);
                    a.click();
                    window.URL.revokeObjectURL(url);
                });
            ClearCache("PdfCache");
        } catch (error) {
            console.log('error', 'خطا: ' + error);
        }
    }


    if (!pdfList || pdfList.length === 0) {



        Swal.fire({
            title: "No project selected!",
            text: "Please select one or more projects",
            imageUrl: "/img/select.png",
            imageWidth: 400,
            imageHeight: 100,
            imageAlt: "Select image"
        });
    }
}

// Function to set a value in cache
function setCache(key, value) {
    localStorage.setItem(key, JSON.stringify({ value: value, expiration: Date.now() + 15 * 60 * 1000 })); // Cache for 3 minutes
}

// Function to get a value from cache
function getCache(key) {
    let cachedData = localStorage.getItem(key);

    if (cachedData) {
        let parsedData = JSON.parse(cachedData);
        if (parsedData.expiration > Date.now()) {
            return parsedData.value;
        } else {
            localStorage.removeItem(key);
            return null;
        }
    } else {
        return null;
    }
}

function ClearCache(key) {
    localStorage.removeItem(key);
}
document.addEventListener('DOMContentLoaded', function () {
    ClearCache("PdfCache");
});


function ShowImage(name,text,image) {

    Swal.fire({
        title:name,
        text: text,
        imageUrl: "/Feedback/"+image+"",
        imageWidth: 400,
     
        imageAlt: "Select image"
    });
}