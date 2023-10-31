<!DOCTYPE html>
<html>

<head>
</head>

<body>

    <style scoped>
        .tracking-container {
            display: flex;

            align-items: center;
            margin: 20px;
        }

        .truck-animation {
            text-align: center;
            margin: 0 20px;
            animation: truckAnimation 2s ease infinite;
        }

        .arrow-animation {
            display: flex;
            align-items: center;
            font-size: 24px;
            margin: 0 20px;
            animation: arrowAnimation 2s ease infinite;
        }

        .date-container {
            text-align: center;
            margin-top: 20px;
        }

        .tracking-date {
            font-size: 18px;
            /* Ajusta el tamaño de fuente según tus preferencias */
            font-weight: bold;
            /* Opcionalmente, puedes hacer que la fecha sea más llamativa */
            color: #007bff;
            /* Cambia el color de la fecha según tu diseño */
        }

        .additional-info {
            text-align: center;
            margin-top: 20px;
        }


        @keyframes truckAnimation {
            0% {
                transform: translateY(0);
            }

            50% {
                transform: translateY(-10px);
            }

            100% {
                transform: translateY(0);
            }
        }

        @keyframes arrowAnimation {
            0% {
                transform: translateX(0);
            }

            50% {
                transform: translateX(10px);
            }

            100% {
                transform: translateX(0);
            }
        }
    </style>



    <?php include 'header.php'; ?>
    <div id="app">
        <v-app>
            <template>
                <div class="container mt-1">

                    <div class="row">
                        <div class="col-md-8">

                            <div class="card">
                                <div class="card-header">
                                    Formulario de Producto
                                </div>
                                <div class="card-body">
                                    <form @submit.prevent="postProducto">
                                        <div class="form-group">
                                            <label for="productName">Nombre del Producto:</label>
                                            <input type="text" class="form-control" id="productName"
                                                v-model="product.NOMBRE" placeholder="Nombre del producto">
                                        </div>

                                        <div class="form-group">
                                            <label for="productDesc">Descripción:</label>
                                            <input type="text" class="form-control" id="productDesc"
                                                v-model="product.DESCRIPCION" placeholder="Descripción del producto">
                                        </div>

                                        <div class="form-group">
                                            <label for="productPrice">Precio:</label>
                                            <input type="number" class="form-control" id="productPrice" step="any"
                                                v-model="product.PRECIO" placeholder="Precio">
                                        </div>

                                        <div class="form-group">
                                            <label for="productStockActual">Stock Actual:</label>
                                            <input type="number" class="form-control" id="productStockActual"
                                                v-model="product.STOCK_ACTUAL" placeholder="Stock Actual">
                                        </div>

                                        <div class="form-group">
                                            <label for="productImage">Imagen (URL):</label>
                                            <input type="text" class="form-control" id="productImage"
                                                v-model="product.IMAGEN" placeholder="URL de la Imagen">
                                        </div>

                                        <div class="form-group">
                                            <label for="sucursalSelect">Sucursal:</label>
                                            <select class="form-control" id="sucursalSelect"
                                                v-model="product.SUCURSAL_ID" @change="onChangeSucursal">
                                                <option v-for="sucursal in sucursales" :value="sucursal.SUCURSAL_ID">{{
                                                    sucursal.NOMBRE
                                                    }}</option>
                                            </select>
                                        </div>

                                        <div class="form-group">
                                            <label for="recetaSelect">Receta:</label>
                                            <select class="form-control" id="recetaSelect" v-model="product.RECETA_ID"
                                                @change="handleRecetaChange($event)">
                                                <option v-for="receta in recetas" :value="receta.RECETA_ID">{{
                                                    receta.NOMBRE }}
                                                </option>
                                            </select>
                                        </div>

                                        <button type="submit" class="btn btn-primary">Enviar</button>
                                    </form>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-4 d-flex flex-column">
                            <div class="row">
                                <div class="card w-100">
                                    <div class="card-header">
                                        Sucursal elegida
                                    </div>
                                    <div class="card-body">


                                        <div class="col-md-11">
                                            <div class="additional-info">
                                                <h4 style="color: blue;">
                                                    <i class="fas fa-store"></i> <!-- Ícono de tienda -->
                                                    {{sucursal.NOMBRE}}
                                                </h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br>
                            <br>
                            <div class="row">
                                <div class="card w-100">
                                    <div class="card-header">
                                        Detalle de receta
                                    </div>
                                    <div class="card-body">


                                        <div class="col-md-11">
                                            <div class="additional-info">
                                                <h4 style="color: blue;">
                                                    #{{receta.RECETA_ID}} {{receta.NOMBRE}}
                                                </h4>
                                                <p style="color: blue;">
                                                    {{receta.DESCRIPCION}}
                                                </p>

                                            </div>
                                        </div>


                                        <table class="table mt-4">
                                            <thead>
                                                <tr>
                                                    <th>Ingrediente</th>
                                                    <th>Unidad de medida</th>
                                                    <th>Cantidad Necesaria</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <!-- Aquí puedes iterar sobre los detalles y mostrarlos en la tabla -->
                                                <tr v-for="(detalle, index) in receta.DetallesReceta" :key="index">
                                                    <td>{{ detalle.NOMBRE2 }}</td>
                                                    <td>{{ detalle.NOMBRE }}</td>
                                                    <td>{{ detalle.CANTIDAD_NECESARIA }}</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </template>


        </v-app>

    </div>
    <?php include 'footer.php'; ?>


    <script src="https://cdn.jsdelivr.net/npm/vue@2.x/dist/vue.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/vuetify@2.x/dist/vuetify.js"></script>
    <script src="js/main.js"></script>
    <script src="js/pedido.js"></script>
</body>

</html>