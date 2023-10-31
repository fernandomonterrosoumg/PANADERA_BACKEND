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
        <div>
            <v-app class="d-flex p-4">
                <v-main>

                    <template>
                        <v-stepper v-model="e1">
                            <v-stepper-header>
                                <v-stepper-step :complete="errors.step1" step="1">
                                    Información de pedido
                                </v-stepper-step>

                                <v-divider></v-divider>

                                <v-stepper-step :complete="errors.step2" step="2">
                                    Detalles de pedido
                                </v-stepper-step>

                            </v-stepper-header>

                            <v-stepper-items>
                                <v-stepper-content step="1">
                                    <div>
                                        <form @submit.prevent="validarPaso1">
                                            <div class="form-row">
                                                <div class="col-md-6 mb-3">
                                                    <label for="validationServer01">Responsable</label>
                                                    <input type="text" class="form-control" disabled
                                                        id="validationServer01" placeholder="First name"
                                                        v-model="userInfo.usuario.nombre" required />
                                                </div>
                                                <div class="col-md-6 mb-3">
                                                    <label for="sucursalSelect">Fecha programación</label>
                                                    <input type="text" class="form-control blanco vm-date" id="vm-date"
                                                        v-model="pedidoForm.pedido.FECHA_PEDIDO" required />
                                                </div>
                                                <div class="col-md-12 mb-3">
                                                    <label for="descripcionSelect">Ruta</label>
                                                    <select class="form-control" v-model="pedidoForm.pedido.RUTA_ID"
                                                        @change="handleRutaChange($event)" required>
                                                        <option v-for="ruta in rutas" :key="ruta.rutA_ID"
                                                            :value="ruta.rutA_ID">
                                                            {{ ruta.rutA_ID }} | {{ ruta.descripcion }}
                                                        </option>
                                                    </select>
                                                </div>
                                                <transition name="fade">
                                                    <div v-show="infoRutaById.nombre_fin !== null"
                                                        class="col-md-12 mb-3">
                                                        <div class="row">
                                                            <div class="container mt-4">
                                                                <div class="card border-primary">
                                                                    <div class="card-header bg-primary text-white">
                                                                        <h3 class="card-title">Detalles de ruta</h3>
                                                                    </div>
                                                                    <div class="card-body">
                                                                        <div class="row">
                                                                            <!-- Cuadro para las imágenes -->
                                                                            <div class="col-md-6">
                                                                                <div class="tracking-container">
                                                                                    <div class="truck-animation">
                                                                                        <img src="https://www.combexim.com.gt/consultas/images/tracking/despacho_de_carga.png"
                                                                                            alt="Inicio"
                                                                                            width="130px" />
                                                                                        <p>Sucursal de salida</p>

                                                                                        <p>{{ infoRutaById.nombre_inicio
                                                                                            }}
                                                                                        </p>
                                                                                    </div>
                                                                                    <div class="arrow-animation">
                                                                                        <!-- Puedes usar una imagen de una flecha o CSS para la animación de movimiento -->
                                                                                        <i
                                                                                            class="fas fa-arrow-right"></i>
                                                                                    </div>
                                                                                    <div class="truck-animation">
                                                                                        <img src="https://www.combexim.com.gt/consultas/images/tracking/salida_carga_combexim.png"
                                                                                            alt="Fin" width="130px" />
                                                                                        <p>Sucursal de llegada</p>

                                                                                        <p>{{ infoRutaById.nombre_fin }}
                                                                                        </p>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <!-- Cuadro para los detalles -->

                                                                            <div class="col-md-6">
                                                                                <div class="row">
                                                                                    <div class="col-md-1 vertical-line">
                                                                                    </div> <!-- Línea vertical -->
                                                                                    <div class="col-md-11">
                                                                                        <div class="additional-info">
                                                                                            <h4 style="color: blue;">
                                                                                                Información adicional
                                                                                            </h4>
                                                                                            <table class="table">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <th>Distancia:
                                                                                                        </th>
                                                                                                        <td>{{
                                                                                                            infoRutaById.distancia
                                                                                                            }}
                                                                                                            kilómetros
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <th>Descripción
                                                                                                            de
                                                                                                            ruta:</th>
                                                                                                        <td>{{
                                                                                                            infoRutaById.descripcion
                                                                                                            }}</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <th>Tipo de
                                                                                                            vehiculo:
                                                                                                        </th>
                                                                                                        <td>{{
                                                                                                            infoRutaById.tipo
                                                                                                            }}</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <th>Descripción
                                                                                                            de
                                                                                                            transporte:
                                                                                                        </th>
                                                                                                        <td>{{
                                                                                                            infoRutaById.descripcion_transporte
                                                                                                            }}</td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </transition>
                                            </div>

                                            <div class="form-group">
                                                <div class="form-check">
                                                    <input class="form-check-input is-invalid" type="checkbox" value=""
                                                        id="invalidCheck3" required />
                                                    <label class="form-check-label" for="invalidCheck3">
                                                        Agree to terms and conditions
                                                    </label>
                                                    <div class="invalid-feedback">You must agree before submitting.
                                                    </div>
                                                </div>
                                            </div>

                                            <v-divider></v-divider>
                                            <v-btn color="primary" type="submit">
                                                Continue
                                            </v-btn>

                                        </form>
                                    </div>
                                </v-stepper-content>

                                <v-stepper-content step="2">
                                    <div id="formaPedido">
                                        <form @submit.prevent="agregarDetalleGenerico('pedidoDet')">
                                            <div class="form-row">
                                                <div class="col-md-12 mb-3">
                                                    <label for="validationServer01">Despacha</label>
                                                    <input type="text" class="form-control" disabled
                                                        id="validationServer01" placeholder="First name"
                                                        v-model="sucursal.NOMBRE" required />
                                                    <div class="valid-feedback">Looks good!</div>
                                                </div>

                                                <div class="col-md-12 mb-3">
                                                    <label for="descripcionSelect">Productos</label>
                                                    <v-autocomplete v-model="pedidoDetalleModel.PRODUCTO_ID"
                                                        :items="productosByTienda" :item-text="InputProductoSel"
                                                        item-value="PRODUCTO_ID" @change="handleProductoChange($event)"
                                                        variant="solo-filled" required>
                                                    </v-autocomplete>
                                                </div>

                                                <div class="col-md-12 mb-3">
                                                    <label for="cantidad">Cantidad Necesaria</label>
                                                    <input v-model="pedidoDetalleModel.CANTIDAD" type="number"
                                                        class="form-control" id="cantidad"
                                                        placeholder="Ingresa la cantidad necesaria" required>
                                                </div>
                                                <transition name="fade">
                                                    <div v-show="pedidoDetalleModel.PRODUCTO_ID!=null"
                                                        class="col-md-12 mb-3">
                                                        <div class="row">
                                                            <div class="container mt-4">
                                                                <div class="card border-primary">
                                                                    <div class="card-header bg-primary text-white">
                                                                        <h3 class="card-title">Detalles de producto</h3>
                                                                    </div>
                                                                    <div class="card-body">
                                                                        <div class="row">
                                                                            <!-- Cuadro para las imágenes -->
                                                                            <div class="col-md-6">
                                                                                <div class="tracking-container">
                                                                                    <div class="truck-animation">
                                                                                        <img :src="productoSelected.IMAGEN"
                                                                                            alt="Inicio"
                                                                                            width="130px" />
                                                                                        <p>Nombre del producto:</p>
                                                                                        <p>{{ productoSelected.NOMBRE }}
                                                                                        </p>
                                                                                        <p>Stock actual:</p>
                                                                                        <p>{{
                                                                                            productoSelected.STOCK_ACTUAL
                                                                                            -
                                                                                            pedidoDetalleModel.CANTIDAD}}
                                                                                        </p>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <!-- Cuadro para los detalles -->

                                                                            <div class="col-md-6">
                                                                                <div class="row">
                                                                                    <div class="col-md-1 vertical-line">
                                                                                    </div> <!-- Línea vertical -->
                                                                                    <div class="col-md-11">
                                                                                        <div v-if="recetaAndDetByProd.length!=0"
                                                                                            class="additional-info">
                                                                                            <h4 style="color: blue;">
                                                                                                Información adicional
                                                                                            </h4>
                                                                                            <h5 style="color: blue;">
                                                                                                Receta:
                                                                                                {{recetaAndDetByProd[0].NOMBRE}}
                                                                                            </h5>
                                                                                            <h6 style="color: blue;">
                                                                                                Descripcion: </h6>
                                                                                            <h6 style="color: blue;">
                                                                                                {{recetaAndDetByProd[0].DESCRIPCION}}
                                                                                            </h6>
                                                                                            <table
                                                                                                class="table table-bordered">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>Ingrediente
                                                                                                        </th>
                                                                                                        <th>Descripcion
                                                                                                            de
                                                                                                            ingrediente
                                                                                                        </th>
                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <tbody>
                                                                                                    <tr v-for="receta in recetaAndDetByProd"
                                                                                                        :key="receta.RECETA_DETALLE_ID">
                                                                                                        <td>{{
                                                                                                            receta.NOMBRE1
                                                                                                            }}</td>
                                                                                                        <td>{{
                                                                                                            receta.DESCRIPCION1
                                                                                                            }}</td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </transition>
                                            </div>
                                            <div class="form-group">
                                                <button type="submit" class="btn btn-primary">Agregar</button>
                                            </div>
                                        </form>

                                        <div class="card-body">
                                            <table id="tablaPedido" class="table mt-4">
                                                <thead>
                                                    <tr>
                                                        <th>Producto</th>
                                                        <th>Cantidad</th>
                                                        <th>Precio unidad</th>
                                                        <th>Precio</th>
                                                        <th>Opciones</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <!-- Aquí puedes iterar sobre los detalles y mostrarlos en la tabla -->
                                                    <tr v-for="(detalle, index) in pedidoForm.detalles" :key="index">
                                                        <td>{{ detalle.mayorInfo.NOMBRE }}</td>
                                                        <td>{{ detalle.CANTIDAD }}</td>
                                                        <td>{{ formatoMoneda(detalle.mayorInfo.PRECIO) }}</td>
                                                        <td>{{ formatoMoneda(detalle.mayorInfo.PRECIO * detalle.CANTIDAD)}}</td>
                                                        <td>
                                                            <button
                                                                @click="eliminarDetalleGenerico('pedidoDet', pedidoForm.detalles, index)"
                                                                class="btn btn-danger">Eliminar</button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td class="text-right">Total:</td>
                                                        <td>{{ totalCantidadPedido}}</td>
                                                        <td></td>
                                                        <td>{{ formatoMoneda(totalPrecioPedido) }}</td>
                                                        <td></td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>

                                        <v-divider></v-divider>
                                        <v-btn color="primary" @click="validarPaso2" type="button">
                                            Guardar
                                        </v-btn>


                                        <v-btn color="primary" @click="e1 = 1">
                                            Atras
                                        </v-btn>
                                        <v-btn color="primary" @click="imprimir('formaPedido')">
                                            Imprimir orden
                                        </v-btn>

                                    </div>
                                </v-stepper-content>
                            </v-stepper-items>
                        </v-stepper>
                    </template>
                </v-main>
            </v-app>
        </div>


    </div>
    <?php include 'footer.php'; ?>


    <script src="https://cdn.jsdelivr.net/npm/vue@2.x/dist/vue.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/vuetify@2.x/dist/vuetify.js"></script>
    <script src="js/main.js"></script>
    <script src="js/pedido.js"></script>
</body>

</html>