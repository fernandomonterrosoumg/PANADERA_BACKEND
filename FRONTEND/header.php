<!DOCTYPE html>
<html lang="en">

<head>


    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link href="https://fonts.googleapis.com/css2?family=Nunito+Sans&family=Nunito:wght@600;700;800&display=swap"
        rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <link href="https://cdn.jsdelivr.net/npm/vuetify@2.x/dist/vuetify.min.css" rel="stylesheet">

    <!-- Flaticon Font -->
    <link href="lib/flaticon/font/flaticon.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">


    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet">
</head>


<div class="container-fluid">
    <div class="row bg-secondary py-2 px-lg-5">
        <div class="col-lg-6 text-center text-lg-left mb-2 mb-lg-0">
            <div class="d-inline-flex align-items-center">
                <a class="text-white pr-3" href="">FAQs</a>
                <span class="text-white">|</span>
                <a class="text-white px-3" href="">Help</a>
                <span class="text-white">|</span>
                <a class="text-white pl-3" href="">Support</a>
            </div>
        </div>
        <div class="col-lg-6 text-center text-lg-right">
            <div class="d-inline-flex align-items-center">
                <a class="text-white px-3" href="">
                    <i class="fab fa-facebook-f"></i>
                </a>
                <a class="text-white px-3" href="">
                    <i class="fab fa-twitter"></i>
                </a>
                <a class="text-white px-3" href="">
                    <i class="fab fa-linkedin-in"></i>
                </a>
                <a class="text-white px-3" href="">
                    <i class="fab fa-instagram"></i>
                </a>
                <a class="text-white pl-3" href="">
                    <i class="fab fa-youtube"></i>
                </a>
            </div>
        </div>
    </div>
    <div class="row py-3 px-lg-5">
        <div class="col-lg-4">
            <a href="" class="navbar-brand d-none d-lg-block">
                <h1 class="m-0 display-5 text-capitalize"><span class="text-primary">San</span>Carlos</h1>
            </a>
        </div>
        <div class="col-lg-8 text-center text-lg-right">
            <div class="d-inline-flex align-items-center">
                <div class="d-inline-flex flex-column text-center pr-3 border-right">
                    <h6>Opening Hours</h6>
                    <p class="m-0">8.00AM - 9.00PM</p>
                </div>
                <div class="d-inline-flex flex-column text-center px-3 border-right">
                    <h6>Email Us</h6>
                    <p class="m-0">info@example.com</p>
                </div>
                <div class="d-inline-flex flex-column text-center pl-3">
                    <h6>Call Us</h6>
                    <p class="m-0">+012 345 6789</p>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Topbar End -->


<!-- Navbar Start -->
<div class="container-fluid p-0">
    <nav class="navbar navbar-expand-lg bg-dark navbar-dark py-3 py-lg-0 px-lg-5">
        <a href="" class="navbar-brand d-block d-lg-none">
            <h1 class="m-0 display-5 text-capitalize font-italic text-white"><span
                    class="text-primary">Safety</span>First</h1>
        </a>
        <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse justify-content-between px-3" id="navbarCollapse">
            <div class="navbar-nav mr-auto py-0">
                <a href="producto.php" class="nav-item nav-link active">Agregar productos</a>
                <a href="receta.php" class="nav-item nav-link">Agregar recetas</a>
                <a href="pedido.php" class="nav-item nav-link">Pedidos</a>
                <a href="mantenimientos.php" class="nav-item nav-link">Mantenimientos</a>
                <a id="logoutButton" class="nav-item nav-link">Cerrar Sesión</a>
            </div>
            <a href="" class="btn btn-lg btn-primary px-3 d-none d-lg-block">Get Quote</a>
        </div>
    </nav>
</div>
<!-- Navbar End -->


<div id="loading" class="loading loading--plane" title="Loading">
    cargando...
    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 113.5 104">
        <path d="M97.7 41.5c16.3 0 16.3 21-.2 21H66.7l-26 38H29.2l14.1-38h-23l-7.8
                        10h-9L8.2 52 3.5 31.5h9l7.8 10h23.1l-14.1-38h11.4l26 38h31z" fill="none" stroke="#231F20" stroke-width="7"
            stroke-linecap="round" stroke-linejoin="round" stroke-miterlimit="10" stroke="#000" stroke-width="4" />
    </svg>
</div>




<!-- JavaScript Libraries -->
<script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
<script src="lib/easing/easing.min.js"></script>
<script src="lib/owlcarousel/owl.carousel.min.js"></script>
<script src="lib/tempusdominus/js/moment.min.js"></script>
<script src="lib/tempusdominus/js/moment-timezone.min.js"></script>
<script src="lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"></script>

<!-- Contact Javascript File -->
<script src="mail/jqBootstrapValidation.min.js"></script>
<script src="mail/contact.js"></script>


<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
<script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>


<script src="https://cdn.jsdelivr.net/npm/vue@2.x/dist/vue.js"></script>
<script src="https://cdn.jsdelivr.net/npm/vuetify@2.x/dist/vuetify.js"></script>
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
<script src="js/httpInterceptor.js"></script>
<script>

    this.fetchIntercept.register({
        request: function (url, config) {
            $("#loading").css("display", "block");
            return [url, config];
        },

        requestError: function (error) {
            $("#loading").css("display", "none");
            return Promise.reject(error);
        },

        response: function (response) {
            $("#loading").css("display", "none");
            return response;
        },

        responseError: function (error) {
            $("#loading").css("display", "none");
            return Promise.reject(error);
        },
    });

    document.getElementById('logoutButton').addEventListener('click', function () {
        // Limpia las variables de sesión
        sessionStorage.removeItem("usuario");
        sessionStorage.removeItem("sessionCreationTime");

        // Redirige al usuario a login.php
        window.location.href = "login.php";
    });

    function checkSession() {
        const usuario = sessionStorage.getItem("usuario");
        const sessionCreationTime = sessionStorage.getItem("sessionCreationTime");

        if (!usuario) {
            window.location.href = "login.php";
            return;
        }

        // Si no existe un tiempo de creación de la sesión, lo establecemos ahora
        if (!sessionCreationTime) {
            sessionStorage.setItem("sessionCreationTime", new Date().toISOString());
        } else {
            const currentTime = new Date();
            const creationTime = new Date(sessionCreationTime);

            // Si ha pasado más de un día (24 horas * 60 minutos * 60 segundos * 1000 milisegundos)
            if (currentTime - creationTime > 24 * 60 * 60 * 1000) {
                // Limpiar la variable de sesión y redirigir al usuario a login.php
                sessionStorage.removeItem("usuario");
                sessionStorage.removeItem("sessionCreationTime");
                window.location.href = "login.php";
            }
        }
    }

    window.onload = checkSession;

</script>





</html>