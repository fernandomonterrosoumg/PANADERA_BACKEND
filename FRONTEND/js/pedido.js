
var enpoint = "https://localhost:7173/api";
new Vue({
    el: '#app',  // Elemento en el que se montará Vue
    vuetify: new Vuetify(),
    data: {
        e1: 1,
        errors: {
            step1: false,
            step2: false,
        },
        tablePedidos: [],
        mensaje: '¡Hola desde Vue.js!',
        sucursales: [],
        rutas: [],
        ingredientes: [],
        medidasUnidad: [],
        productosByTienda: [],
        recetaAndDetByProd: [],
        oldVal: "",
        newVal: "",
        datosTablas: [],
        recetas: [],
        selectedTable: '', // modelo para el select
        tableOptions: [
            { label: 'Detalles pedido', value: 'getPedidoYDetalles' },
            { label: 'Medidas', value: 'getUnidadesMedida' },
            { label: 'Pedidos', value: 'GetPedidos' },
            { label: 'Recetas', value: 'GetRecetas' },
            { label: 'Productos', value: 'GetProductos' },
            { label: 'Usuarios', value: 'getUsuarios' },
            { label: 'Turnos', value: 'GetTurnos' },
            { label: 'Transportes', value: 'GetTransportes' },
            { label: 'Sucursal', value: 'GetSucursales' },
            { label: 'Status', value: 'GetStatus' },
            { label: 'Rutas', value: 'GetRutas' },
            { label: 'Rol Tipo', value: 'getRolTipos' },
            { label: 'Mini Sistema', value: 'getMiniSistems' },
            { label: 'Ingredientes', value: 'GetIngredientes' },
            { label: 'Factura Detalle', value: 'getFacturaDetalles' },
            { label: 'Facturas', value: 'getFacturas' }
        ],
        sucursal: {
            "SUCURSAL_ID": null,
            "NOMBRE": null,
            "DIRECCION": null,
            "TELEFONO": null,
            "EMAIL": null,
            "CONEXION_INTERNET": null
        },
        productoSelected: {
            "PRODUCTO_ID": null,
            "RECETA_ID": 0,
            "NOMBRE": null,
            "DESCRIPCION": null,
            "SUCURSAL_ID": null,
            "PRECIO": null,
            "IMAGEN": null,
            "STOCK_ORIGINAL": null,
            "STOCK_ACTUAL": null,
            IMAGEN: null,

        },
        userInfo: {
            "usuario": {
                "usuariO_ID": null,
                "nombre": null,
                "usuario": null,
                "contrasena": null,
                "fechaCreacion": null,
                "ultimoIngreso": null,
                "roL_TIPO_ID": null,
                "rolNombre": null,
                "rolDescripcion": null
            },
            "token": null
        },
        receta: {
            NOMBRE: '',
            DESCRIPCION: '',
            RECETA_ID: 0,
            DetallesReceta: []
        },
        RecetaDetalle: {
            RECETA_ID: 0,
            INGREDIENTE_ID: null,
            CANTIDAD_NECESARIA: null,
            UNIDAD_MEDIDA_ID: null,
            UNIDAD_MEDIDA: {},
            INGREDIENTE: {},
        },
        product: {
            "PRODUCTO_ID": 0,
            "RECETA_ID": 0,
            "NOMBRE": null,
            "DESCRIPCION": null,
            "SUCURSAL_ID": 0,
            "PRECIO": 0.00,
            "IMAGEN": null,
            "STOCK_ORIGINAL": 0,
            "STOCK_ACTUAL": 0
        },
        pedidoForm: {
            "pedido": {
                "PEDIDO_ID": 0,
                "CANTIDAD_SOLICITADA": 0,
                "FECHA_PEDIDO": null,
                "FECHA_DESPACHO": null,
                "USUARIO_ID": null,
                "FECHA_INGRESO_REAL": null,
                "RUTA_ID": null
            },
            "detalles": [
            ]
        }, pedidoDetalleModel: {
            "PEDIDO_DET_ID": 0,
            "PEDIDO_ID": 0,
            "CANTIDAD": 0,
            "PRODUCTO_ID": null
        }, infoRutaById: {
            "nombre_inicio": null,
            "nombre_fin": null,
            "ruta_id": null,
            "distancia": null,
            "descripcion": null,
            "descripcion_transporte": null,
            "tipo": null
        }, addProducto: {
            "PRODUCTO_ID": 0,
            "RECETA_ID": 0,
            "NOMBRE": null,
            "DESCRIPCION": null,
            "SUCURSAL_ID": 0,
            "PRECIO": 0.00,
            "IMAGEN": null,
            "STOCK_ORIGINAL": 0,
            "STOCK_ACTUAL": 0
        }

    },

    // Propiedades computadas
    computed: {
        totalPrecioPedido() {
            return this.pedidoForm.detalles.reduce((acc, detalle) => {
                return acc + (detalle.mayorInfo.PRECIO * detalle.CANTIDAD);
            }, 0);
        },
        totalCantidadPedido() {
            return this.pedidoForm.detalles.reduce((acc, detalle) => {
                return acc + Number(detalle.CANTIDAD);
            }, 0);
        },
        mensajeMayusculas() {
            return this.mensaje.toUpperCase();
        },
        userToken: function () {
            try {
                this.userInfo = JSON.parse(sessionStorage.getItem("usuario"));
                if (this.userInfo && this.userInfo.token) {
                    return this.userInfo.token;
                } else {
                    throw new Error("Token no existe en el objeto 'usuario'.");
                }

            } catch (error) {
                this.ErrorSwal("Error al obtener el token: " + error.message);
                return null;
            }
        },
    },

    // Métodos
    methods: {
        limpiarEstructura(estructura) {
            if (Array.isArray(estructura)) {
                return [];
            } else if (typeof estructura === 'object') {
                const newObj = {};
                for (const key in estructura) {
                    newObj[key] = this.limpiarEstructura(estructura[key]);
                }
                return newObj;
            } else if (typeof estructura === 'string') {
                return "";
            } else if (typeof estructura === 'number') {
                return 0;
            } else {
                return null; // para otros tipos de datos (null, undefined, etc.)
            }
        },
        validarPaso1() {
            if (
                this.userInfo.usuario.nombre &&
                this.pedidoForm.pedido.FECHA_PEDIDO &&
                this.pedidoForm.pedido.RUTA_ID
            ) {
                this.errors.step1 = false;
                this.e1 = 2;
                this.getProductosByTienda(this.sucursal.SUCURSAL_ID);
            } else {
                this.errors.step1 = true;
            }
        },
        validarPaso2() {
            // Agrega la validación del paso 2 aquí si es necesario
            if (this.pedidoForm.detalles.length === 0) {
                this.errors.step2 = false;
                this.e1 = 3;
            } else {
                this.postPedido();
                this.errors.step2 = true;
            }
        }, SuccessSwal(text, options = {}) {
            const { icon = "success", title = "Éxito" } = options;
            Swal.fire({
                icon: icon,
                title: title,
                text: text,
                heightAuto: false,
            });
        },
        formatoMoneda(valor) {
            return new Intl.NumberFormat('es-GT', {
                style: 'currency',
                currency: 'GTQ',
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }).format(valor);
        }, ErrorSwal(text, options = {}) {
            const { icon = "error", title = "Oops..." } = options;
            Swal.fire({
                icon: icon,
                title: title,
                text: text,
                heightAuto: false,
            });
        }, postProducto() {
            console.log(this.product);
            var self = this;
            fetch(`${enpoint}/Negocio/setProducto`, {
                method: "POST",
                body: JSON.stringify(self.product),
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.product = self.limpiarEstructura(self.product);
                        return self.SuccessSwal(res.message);
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, postPedido() {
            var self = this;
            fetch(`${enpoint}/Negocio/postPedido`, {
                method: "POST",
                body: JSON.stringify(self.pedidoForm),
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        //self.pedidoForm = self.limpiarEstructura(self.pedidoForm);
                        return self.SuccessSwal(res.message);
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, postRecetaYDetalles() {
            var self = this;
            fetch(`${enpoint}/Negocio/postRecetaYDetalles`, {
                method: "POST",
                body: JSON.stringify(self.receta),
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        return self.SuccessSwal("Receta guardada con éxito", { title: "¡Genial!" });
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, cambiarMensaje() {
            this.mensaje = 'Mensaje cambiado';
        },
        agregarDetalleGenerico(tipo) {
            if (tipo == "recetaDet") {
                this.RecetaDetalle.UNIDAD_MEDIDA_ID = this.RecetaDetalle.UNIDAD_MEDIDA.UNIDAD_MEDIDA_ID;
                this.RecetaDetalle.INGREDIENTE_ID = this.RecetaDetalle.INGREDIENTE.INGREDIENTE_ID;

                // Buscar si el ingrediente ya existe en el array
                const existingDetalle = this.receta.DetallesReceta.find(detalle => detalle.INGREDIENTE_ID === this.RecetaDetalle.INGREDIENTE_ID);

                if (existingDetalle) {
                    // Si el ingrediente ya existe en el array, sumar la cantidad necesaria
                    existingDetalle.CANTIDAD_NECESARIA += this.RecetaDetalle.CANTIDAD_NECESARIA;
                } else {
                    // Si el ingrediente no existe en el array, agregarlo
                    this.receta.DetallesReceta.push(this.RecetaDetalle);
                }

                console.log(JSON.stringify(this.receta));

                // Limpia el formulario después de enviar los datos
                this.RecetaDetalle = {
                    RECETA_ID: 0,
                    INGREDIENTE_ID: null,
                    CANTIDAD_NECESARIA: null,
                    UNIDAD_MEDIDA_ID: null
                }

            } else if (tipo == "pedidoDet") {
                this.pedidoDetalleModel.mayorInfo = this.productoSelected;

                // Buscar si el producto ya existe en el array
                const existingDetalle = this.pedidoForm.detalles.find(detalle => detalle.PRODUCTO_ID === this.pedidoDetalleModel.PRODUCTO_ID);

                if (existingDetalle) {
                    // Si el producto ya existe en el array, sumar la cantidad
                    existingDetalle.CANTIDAD = Number(existingDetalle.CANTIDAD) + Number(this.pedidoDetalleModel.CANTIDAD);
                } else {
                    // Si el producto no existe en el array, agregarlo
                    let detalleCopy = JSON.parse(JSON.stringify(this.pedidoDetalleModel));
                    this.pedidoForm.detalles.push(detalleCopy);
                }

                console.log(JSON.stringify(this.pedidoForm));

                // Limpia el formulario después de enviar los datos
                this.pedidoDetalleModel = {
                    "PEDIDO_DET_ID": 0,
                    "PEDIDO_ID": 0,
                    "CANTIDAD": 0,
                    "PRODUCTO_ID": null
                }
            }
        }, imprimir(elementId) {
            let elemento = document.getElementById(elementId);
            if (!elemento) {
                console.error(`Elemento con ID ${elementId} no encontrado.`);
                return;
            }

            let contenido = elemento.outerHTML;
            let ventana = window.open('', '_blank');
            ventana.document.write('<html><head><title>Imprimir</title></head><body>');
            ventana.document.write(contenido);
            ventana.document.write('</body></html>');
            ventana.document.close();

            ventana.print();
        }, InputProductoSel(producto) {
            return `${producto.PRODUCTO_ID} | ${producto.NOMBRE}`;
        }, eliminarDetalleGenerico(tipo, modelo, index) {
            modelo.splice(index, 1);
        }, getInterSucursalById(id) {
            var self = this;
            self.sucursal = self.sucursales.find(x => x.SUCURSAL_ID === id);
        }, getProductosByTienda(sucursal_id) {
            var self = this;
            fetch(`${enpoint}/Negocio/getProductosByTienda?sucursal_id=${sucursal_id}`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.productosByTienda = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, shouldShowColumn(key) {
            return key === "PEDIDO_ID" || !key.includes("_ID");
        }, destroyDataTable(tableId) {

            if (tableId !== "#") {
                if ($.fn.dataTable.isDataTable(tableId)) {
                    $(tableId).DataTable().destroy();
                }
            }

        },
        initDataTable(tableId) {
            if (tableId !== "#") {
                $(tableId).DataTable({
                    destroy: true,
                    paging: true,
                    search: true,
                    // ... otras opciones predeterminadas que desees...
                });
            }

        }, getDatos(endpoint) {
            return new Promise((resolve, reject) => {
                var self = this;
                fetch(`${enpoint}/Negocio/${endpoint}`, {
                    method: "GET",
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + this.userToken,
                    },
                })
                    .then((resp) => resp.json())
                    .then((res) => {
                        if (res.status == true) {
                            resolve(res.data); // Resolvemos la promesa con los datos
                        } else if (res.message) {
                            reject(res.message); // Rechazamos la promesa con el mensaje de error
                        } else {
                            reject(JSON.stringify(res)); // Rechazamos la promesa con la respuesta en caso de que no sea un mensaje de error conocido
                        }
                    })
                    .catch(function (error) {
                        self.ErrorSwal(error);
                        reject(error); // También rechazamos la promesa en caso de otros errores, como problemas de red
                    });
            });
        }, getTablaPedidos() {
            var self = this;
            fetch(`${enpoint}/Negocio/getPedidoYDetalles`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.tablePedidos = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, getRecetas() {
            var self = this;
            fetch(`${enpoint}/Negocio/getRecetas`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.recetas = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, getSucursales() {
            var self = this;
            fetch(`${enpoint}/Negocio/getSucursales`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.sucursales = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, getUnidadesMedida() {
            var self = this;
            fetch(`${enpoint}/Negocio/getUnidadesMedida`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.medidasUnidad = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, getIngredientes() {
            var self = this;
            fetch(`${enpoint}/Negocio/getIngredientes`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.ingredientes = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        },
        getRutas() {
            var self = this;
            fetch(`${enpoint}/Negocio/getRutas`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.rutas = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, handleRecetaChange(event) {
            var self = this;
            self.receta = { ...self.recetas.find(x => x.RECETA_ID === parseInt(event.target.value)), DetallesReceta: [] };
            fetch(`${enpoint}/Negocio/getRecetaDetByIdRec?receta_id=${event.target.value}`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.receta.DetallesReceta = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, onChangeSucursal(event) {
            var self = this;
            self.sucursal = self.sucursales.find(x => x.SUCURSAL_ID == event.target.value);
        }, handleRutaChange(event) {
            var self = this;
            fetch(`${enpoint}/Negocio/getInfoRutaById?ruta_id=${event.target.value}`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.infoRutaById = res.data;
                        this.getInterSucursalById(self.infoRutaById.sucursal_id_ini);
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }, transformar(value) {
            if (!isNaN(new Date(value).getTime()) && typeof value === 'string' && value.includes('-')) {
                return this.formatDate(value);
            }
            // else if (typeof value === 'number') {
            //   return this.formatNumber(value);
            // }
            // Agregar más transformadores según sea necesario
            return value;
        }, formatDate(value) {
            const date = new Date(value);
            const options = {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit',
                hour12: false
            };

            return date.toLocaleString('es-ES', options);
        }, async changeTable() {
            try {
                this.datosTablas = await this.getDatos(this.selectedTable);
            } catch (error) {
                self.ErrorSwal(error);
            }
        }, formatKey(key) {
            if (typeof key === 'string') {
                return key.replaceAll('_', ' ').toUpperCase();
            }
            return key;
        }, handleProductoChange(PRODUCTO_ID) {
            var self = this;
            if (PRODUCTO_ID === null) {
                return self.recetaAndDetByProd = [];
            }
            this.productoSelected = this.productosByTienda.find(x => x.PRODUCTO_ID === PRODUCTO_ID);

            if (!this.productoSelected.RECETA_ID) {
                return self.recetaAndDetByProd = [];
            }

            fetch(`${enpoint}/Negocio/getRecetaAndDetById?receta_id=${this.productoSelected.RECETA_ID}`, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.userToken,
                },
            }).then((resp) => resp.json())
                .then((res) => {
                    if (res.status == true) {
                        self.recetaAndDetByProd = res.data;
                    } else if (res.message) {
                        throw res.message;
                    } else {
                        throw JSON.stringify(res);
                    }
                })
                .catch(function (error) {
                    self.ErrorSwal(error);
                });
        }
    },

    // Observadores
    watch: {
        'pedidoForm.detalles': {
            handler() {
                this.pedidoForm.pedido.CANTIDAD_SOLICITADA = this.totalCantidadPedido;
            },
            deep: true
        }, mensaje(newValue, oldValue) {
            console.log(`El mensaje cambió de '${oldValue}' a '${newValue}'`);
        }, selectedTable(newVal, oldVal) {
            this.newVal = newVal;
            this.oldVal = oldVal;
        }, datosTablas(newVal, oldVal) {
            if (newVal && oldVal && newVal !== oldVal && this.oldVal != null) {
                console.error("this.newVal",this.oldVal,this.newVal);
                this.destroyDataTable('#' + this.oldVal);
                this.destroyDataTable('#' + this.newVal);

                this.$nextTick(() => {
                    this.initDataTable('#' + this.newVal);
                });
            }
        }
    },

    // Hooks del ciclo de vida
    beforeCreate() {

    },

    created() {

    },

    beforeMount() {

    },

    mounted() {
        this.getTablaPedidos();
        this.getRecetas();
        this.getUnidadesMedida();
        this.getIngredientes();
        this.getSucursales();
        this.getRutas();
        $(".vm-date").flatpickr({
            dateFormat: "Z", // ISO format for the actual value
            altInput: true,
            altFormat: "d/m/Y H:i",
            enableTime: true,
            minTime: "09:00"
        });

    },

    beforeUpdate() {
        console.log('beforeUpdate()');
    },

    updated() {
        console.log('updated()');
    },

    beforeDestroy() {
        console.log('beforeDestroy()');
    },

    destroyed() {
        console.log('destroyed()');
    }
});
