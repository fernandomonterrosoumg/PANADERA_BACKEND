<!DOCTYPE html>
<html>

<head>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css">
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
                <div class="container">
                    <h1>INFORMACION</h1>
                    <div class="row">
                        <div class="col-md-12">
                            <select v-model="selectedTable" class="form-control" @change="changeTable">
                                <option v-for="option in tableOptions" :key="option.value" :value="option.value">
                                    {{ option.label }}
                                </option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                       
                            <div v-show="selectedTable === 'pedidos'" class="col-md-12">
                                <div class="table-responsive">
                                    <table class="table" id="myDataTable">
                                        <thead>
                                            <tr>
                                                <th v-for="(value, key) in tablePedidos[0]" v-if="shouldShowColumn(key)"
                                                    :key="key">
                                                    {{ formatKey(key) }}
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="pedido in tablePedidos" :key="pedido.PEDIDO_ID">
                                                <td v-for="(value, key) in pedido" v-if="shouldShowColumn(key)"
                                                    :key="key">
                                                    {{ transformar(value) }}
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="col-md-12" >
                                <div class="table-responsive">
                                    <table class="table"  :id="selectedTable">
                                        <thead>
                                            <tr>
                                                <th v-for="(value, key) in datosTablas[0]"
                                                    v-if="shouldShowColumn(key)" :key="key">
                                                    {{ formatKey(key) }}
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="row in datosTablas">
                                                <td v-for="(value, key) in row" v-if="shouldShowColumn(key)" :key="key">
                                                    {{ transformar(value) }}
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
    <script type="text/javascript" charset="utf8"
        src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/vuetify@2.x/dist/vuetify.js"></script>
    <script src="js/main.js"></script>
    <script src="js/pedido.js"></script>
</body>

</html>