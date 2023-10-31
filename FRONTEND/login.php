<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
<div id="app" class="login-page">
    <h1 style="text-align: center;">Sistema de panaderia</h1>
    <div class="form">
        <div v-if="alertMessage" :class="{'alert-danger': isError, 'alert-success': !isError}" class="alert">
            {{ alertMessage }}
        </div>
        <form class="register-form">
            <input type="text" placeholder="name" />
            <input type="password" placeholder="password" />
            <input type="text" placeholder="email address" />
            <button>create</button>
            <p class="message">Already registered? <a href="#">Sign In</a></p>
        </form>
        <form class="login-form" @submit.prevent="login">
            <input type="text" v-model="paramLogin.usuario" :class="{ 'is-invalid': isError }" class="form-control"
                id="validationServerUsername" placeholder="Username" aria-describedby="inputGroupPrepend3" required>
            <!-- <div v-if="isError" class="invalid-feedback">
                {{ alertMessage }}
            </div> -->
            <input type="password" v-model="paramLogin.contrasena" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">Not registered? <a href="#">Create an account</a></p>
        </form>
    </div>
</div>


<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/vue@2.x/dist/vue.js"></script>
<script>
    $('.message a').click(function () {
        $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
    });

    new Vue({
        el: '#app',
        data: {
            mensaje: '¡Hola Vue!',
            paramLogin: {
                usuario: "",
                contrasena: ""
            },
            alertMessage: "",
            isError: false,
        },
        methods: {
            async login() {
                try {
                    const response = await fetch('https://localhost:7173/api/Usuarios/login', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(this.paramLogin),
                    });

                    const data = await response.json();
                    console.log(data);
                    if (data.status) {
                        this.isError = false;
                        this.alertMessage = data.message;
                        sessionStorage.setItem("usuario", JSON.stringify(data.data));
                        window.location.href = "pedido.php";

                    } else {
                        console.log("llego aca");
                        this.isError = true;
                        this.alertMessage = data.message;
                    }

                } catch (error) {
                    this.isError = true;
                    this.alertMessage = "Hubo un error al intentar iniciar sesión. " + error;
                }
            },
        },
    });
</script>



<style>
    @import url(https://fonts.googleapis.com/css?family=Roboto:300);

    .login-page {
        width: 360px;
        padding: 8% 0 0;
        margin: auto;
    }

    .form {
        position: relative;
        z-index: 1;
        background: #FFFFFF;
        max-width: 360px;
        margin: 0 auto 100px;
        padding: 45px;
        text-align: center;
        box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
    }

    .form input {
        font-family: "Roboto", sans-serif;
        outline: 0;
        background: #f2f2f2;
        width: 100%;
        border: 0;
        margin: 0 0 15px;
        padding: 15px;
        box-sizing: border-box;
        font-size: 14px;
    }

    .form button {
        font-family: "Roboto", sans-serif;
        text-transform: uppercase;
        outline: 0;
        background: #4CAF50;
        width: 100%;
        border: 0;
        padding: 15px;
        color: #FFFFFF;
        font-size: 14px;
        -webkit-transition: all 0.3 ease;
        transition: all 0.3 ease;
        cursor: pointer;
    }

    .form button:hover,
    .form button:active,
    .form button:focus {
        background: #43A047;
    }

    .form .message {
        margin: 15px 0 0;
        color: #b3b3b3;
        font-size: 12px;
    }

    .form .message a {
        color: #4CAF50;
        text-decoration: none;
    }

    .form .register-form {
        display: none;
    }

    .container {
        position: relative;
        z-index: 1;
        max-width: 300px;
        margin: 0 auto;
    }

    .container:before,
    .container:after {
        content: "";
        display: block;
        clear: both;
    }

    .container .info {
        margin: 50px auto;
        text-align: center;
    }

    .container .info h1 {
        margin: 0 0 15px;
        padding: 0;
        font-size: 36px;
        font-weight: 300;
        color: #1a1a1a;
    }

    .container .info span {
        color: #4d4d4d;
        font-size: 12px;
    }

    .container .info span a {
        color: #000000;
        text-decoration: none;
    }

    .container .info span .fa {
        color: #EF3B3A;
    }

    body {
        background: #76b852;
        /* fallback for old browsers */
        background: rgb(141, 194, 111);
        background: linear-gradient(90deg, rgba(141, 194, 111, 1) 0%, rgba(118, 184, 82, 1) 50%);
        font-family: "Roboto", sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }
</style>