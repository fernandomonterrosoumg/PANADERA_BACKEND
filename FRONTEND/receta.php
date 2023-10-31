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
                <div class="container mt-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card border-primary">
                                <div class="card-header bg-primary text-white">
                                    <h3 class="card-title">Registrar Receta</h3>
                                </div>
                                <div class="card-body">
                                    <!-- Formulario para registrar la receta -->
                                    <form @submit.prevent="postRecetaYDetalles">
                                        <div class="form-group">
                                            <label for="nombre">Nombre:</label>
                                            <input v-model="receta.NOMBRE" type="text" class="form-control" id="nombre"
                                                required placeholder="Ingresa el nombre de la receta">
                                        </div>
                                        <div class="form-group">
                                            <label for="descripcion">Descripción:</label>
                                            <textarea v-model="receta.DESCRIPCION" class="form-control" id="descripcion"
                                                required rows="4"
                                                placeholder="Escribe la descripción de la receta"></textarea>
                                        </div>
                                    </form>
                                </div>

                                <!-- Subtítulo para el ingreso de detalles -->
                                <div class="card-header bg-primary text-white">
                                    <h4>Detalles de la Receta</h4>
                                </div>
                                <div class="card-body">
                                    <!-- Formulario para el detalle de la receta -->
                                    <div class="col-md-12 mb-3">
                                        <select class="form-control" v-model="RecetaDetalle.INGREDIENTE" required>
                                            <option v-for="ingrediente in ingredientes"
                                                :key="ingrediente.INGREDIENTE_ID" :value="ingrediente">{{
                                                ingrediente.NOMBRE }}</option>
                                        </select>
                                    </div>
                                    <div class="col-md-12 mb-3">
                                        <select class="form-control" v-model="RecetaDetalle.UNIDAD_MEDIDA" required>
                                            <option v-for="medida in medidasUnidad" :key="medida.UNIDAD_MEDIDA_ID"
                                                :value="medida">{{ medida.NOMBRE }} | {{ medida.ABREVIATURA }}
                                            </option>
                                        </select>
                                    </div>
                                    <div class="col-md-12 mb-3">
                                        <label for="cantidad">Cantidad Necesaria:</label>
                                        <input v-model="RecetaDetalle.CANTIDAD_NECESARIA" type="number"
                                            class="form-control" id="cantidad"
                                            placeholder="Ingresa la cantidad necesaria" required>
                                    </div>
                                    <button type="button" @click="agregarDetalleGenerico('recetaDet')"
                                        class="btn btn-primary">Agregar
                                        Detalle</button>
                                </div>

                                <!-- Tabla de detalles de la receta -->
                                <div class="card-body">
                                    <table class="table mt-4">
                                        <thead>
                                            <tr>
                                                <th>Ingrediente</th>
                                                <th>Unidad de medida</th>
                                                <th>Cantidad Necesaria</th>
                                                <th>Opciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <!-- Aquí puedes iterar sobre los detalles y mostrarlos en la tabla -->
                                            <tr v-for="(detalle, index) in receta.DetallesReceta" :key="index">
                                                <td>{{ detalle.INGREDIENTE.NOMBRE }}</td>
                                                <td>{{ detalle.UNIDAD_MEDIDA.NOMBRE }}</td>
                                                <td>{{ detalle.CANTIDAD_NECESARIA }}</td>
                                                <td>
                                                    <button
                                                        @click="eliminarDetalleGenerico('recetaDet', receta.DetallesReceta, index)"
                                                        class="btn btn-danger">Eliminar</button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>

                                <!-- Botón para guardar la receta fuera del formulario de detalles -->
                                <div class="card-footer">
                                    <button @click="postRecetaYDetalles" class="btn btn-primary">Guardar Receta</button>
                                </div>
                            </div>
                        </div>
                        <!-- <div class="col-md-4">
                            Contenido de la segunda columna
                        </div> -->
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