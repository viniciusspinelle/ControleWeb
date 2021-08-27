var controle = {

    init: function () {

        this.setup();
        this.toastr();
        
    },

    toastr: function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            //"positionClass": "toast-bottom-center",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showEasing": "easeOutBounce",
            "hideEasing": "easeInBack",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    },



    setup: function () {

        var self = this;
        //this.loginPopup.__init();
        
        $.ajaxSetup({
            cache:false,

            beforeSend: function (jqXHR, settings) {
                controle.blockUI();
            },

            error: function (xhr, ajaxOptions, thrownError) {
                controle.unblockUI();

                if (xhr.status === 401) {
                    controle.showErrorAlert('<strong>Usuário não tem permissão para executar essa ação, por favor entrar em contato com administrador do sistema! </strong><br />');
                }
                else {

                    controle.showErrorAlert(xhr.responseText);
                }

            },
            complete: function (){
                controle.unblockUI();
            }

            //statusCode: {

            //    401: function () {

            //        self.loginPopup.__ajaxRequests.push(this);

            //        self.loginPopup.show();
            //    }
            //}
        });
    },
    

    clearAlert: function () {
        $("#alertPlaceHolder").html("");
    },

    showWarningAlert: function (message, dismiss) {
        toastr.warning(message);
        //this.showAlert('warning', message, dismiss, true);
    },

    showErrorAlert: function (message, dismiss) {
        toastr.error(message);
        //this.showAlert('danger', message, dismiss, true);
    },

    showSuccessAlert: function (message, dismiss) {
        toastr.success(message);
        //this.showAlert('success', message, dismiss, true);
    },

    showRequiredFieldsAlert: function (message, dismiss) {
        toastr.error(message);
        //this.showAlert('danger', message, dismiss, true);
    },

    showAlertaAviso: function (message, id) {

        toastr["warning"](message + "<br /><br /><button  type='button' class='btn btn-primary' onclick='alertaAviso(" + id + ")' style='float:right; margin-right:0%;'>Visualizado</button>", "<label >Aviso Importante<label/>");
    },


    showSuccessPopup: function (title, message, url) {
        content =
            '<div id="msgSaved" class="modal fade bs-example-modal-lg fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' +
            '<div class="modal-dialog modal-lg">' +
             '<div class="modal-content">' +

            '<div class="modal-header">' +
            '    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>' +
            '    <h4 class="modal-title" id="myModalLabel">' + title + '</h3>' +
            '</div>' +
            '<div class="modal-body">' +
            '    <p>' + message + '</p>' +
            '</div>' +
            '<div class="modal-footer">' +
            '    <a href="' + url + '" class="btn btn-primary">Fechar</a>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';

        $("#alertPlaceHolder").html(content);

        $('#msgSaved').modal({ backdrop: 'static', keyboard: false })

    },
    showConfirmationPopup: function (title, message, positiveButton, positiveCallback, negativeButton, negativeCallback) {

        content =
            '<div id="msgConfirmation" class="modal fade bs-example-modal-lg fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' +
            '<div class="modal-dialog modal-lg">' +
             '<div class="modal-content">' +

            '<div class="modal-header">' +
            '    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>' +
            '    <h4 class="modal-title" id="myModalLabel">' + title + '</h3>' +
            '</div>' +
            '<div class="modal-body">' +
            '    <p>' + message + '</p>' +
            '</div>' +
            '<div class="modal-footer">' +
            '    <button type="button" id="negativeButton" data-dismiss="modal" class="btn" href="#">' + negativeButton + '</button>' +
            '    <button type="button" id="positiveButton" data-dismiss="modal" class="btn btn-primary" href="#">' + positiveButton + '</button>' +
           '</div>' +
            '</div>' +
            '</div>' +
            '</div>';

        $("#alertPlaceHolder").html(content);

        $("#msgConfirmation #positiveButton").on("click", positiveCallback);

        if (negativeCallback != null) {
            $("#msgConfirmation #negativeButton").on("click", negativeCallback);
        }

        $('#msgConfirmation').modal({ backdrop: 'static', keyboard: false })

    },

    voltar: function () {
        window.history.back();
    },

    firsDataMonth: function () {
        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        return firstDay;
    },

    lastDataMonth: function () {
        var date = new Date();
        var lastDay = new Date - (date.getFullYear(), date.getMonth() + 1, 0);
        return lastDay;
    },

    validaData: function (data) {

        if (data == null) {
            return false;
        }

        var dia = data.substring(0, 2)
        var mes = data.substring(3, 5)
        var ano = data.substring(6, 10)

        //Criando um objeto Date usando os valores ano, mes e dia.
        var novaData = new Date(ano, (mes - 1), dia);

        var mesmoDia = parseInt(dia, 10) == parseInt(novaData.getDate());
        var mesmoMes = parseInt(mes, 10) == parseInt(novaData.getMonth()) + 1;
        var mesmoAno = parseInt(ano) == parseInt(novaData.getFullYear());

        if (!((mesmoDia) && (mesmoMes) && (mesmoAno))) {
            return false;
        }
        return true;
    },

    formataData: function (value, mask) {
        if (value == null || value == undefined || value == '')
            return null;

        var defaultMask = 'YYYY-MM-DDTHH'; // Formato apenas com data 
        // var defaultMask = 'YYYY-MM-DDTHH:mm:ss.SSSZZ'; //Mascara com data e hora 

        mask = mask || defaultMask;

        if (typeof mask === 'object') {
            mask = mask.dateMask;
        }

        return typeof value === 'string' ? value.length > 0 ? moment(value).format(mask) : '' : moment(value).format(mask);
    },

    LimitCharacter: function (data)
    {
        
        limit=30
        if (data.length > limit)
        {
            data = data.substring(0, limit) + " ..."
            
            return data;
        }
        else
        {
            return data;
        }
    },

    formataCel: function (value) {


        if (value == null || value == undefined || value == '')
            return null;


        value = value.replace(/\D/g, "");
        value = value.replace(/^(\d{2})(\d)/g, "($1) $2");
        value = value.replace(/(\d)(\d{4})$/, "$1-$2");
        return value;
    },

    formataDataExt: function (data) {
        if (data == null || data == undefined) {
            return null;
        }
        var myDate = new Date(data.match(/\d+/)[0] * 1);
        return myDate;
    },

    formataDataMesAno: function (data) {
        if (data == null || data == undefined) {
            return null;
        }
        var myDate = new Date(data.match(/\d+/)[0] * 1);
        var dia = myDate.getDate().toString().length == 1 ? "0" + myDate.getDate() : myDate.getDate();
        var mes = myDate.getMonth() + 1;
        mes = mes.toString().length == 1 ? "0" + mes : mes;

        return mes + "/" + myDate.getFullYear()
    },

    formataMoeda: function (value) {
        if (value === null) {
            return '0.00';
        }

        try {
            var $input = $('<input type="text" value="' + value + '" />');

            $input.maskMoney({
                decimal: ',', // Separador do decimal
                thousands: '.', // Separador para os milhares
                allowZero: true, // Permite que o digito 0 seja o primeiro caractere
                defaultZero: false,
                showSymbol: false // Exibe/Oculta o símbolo
            });

            if ($input.data('precision') == 0) {
                $input.maskMoney('mask', value);
            }
            else {
                $input.maskMoney('mask', parseFloat(value));
            }

            return $input.val();
        }
        catch (exception) {

        }
    },

    formataTelefone: function (v) {

        return v.replace(/(\d{2})(\d{4})(\d{4})/, '($1) $2-$3');
    },

    modelToQueryURL: function (model) {

        return this.jsonToQueryURL(ko.toJS(model));
    },

    FormatCPFCNPJ: function (value) {

        //Remove tudo o que não é dígito
        value = value.replace(/\D/g, "")

        if (value.length <= 14) { //CPF

            //Coloca um ponto entre o terceiro e o quarto dígitos
            value = value.replace(/(\d{5})(\d)/, "$1.$2")

            //Coloca um ponto entre o terceiro e o quarto dígitos
            //de novo (para o segundo bloco de números)
            value = value.replace(/(\d{3})(\d)/, "$1.$2")

            //Coloca um hífen entre o terceiro e o quarto dígitos
            value = value.replace(/(\d{3})(\d{1,2})$/, "$1-$2")

        } else { //CNPJ
            //Coloca ponto entre o segundo e o terceiro dígitos
            value = value.replace(/^(\d{2})(\d)/, "$1.$2")

            //Coloca ponto entre o quinto e o sexto dígitos
            value = value.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")

            //Coloca uma barra entre o oitavo e o nono dígitos
            value = value.replace(/\.(\d{3})(\d)/, ".$1/$2")

            //Coloca um hífen depois do bloco de quatro dígitos
            value = value.replace(/(\d{4})(\d)/, "$1-$2")
        }

        return value

    },

    blockUI: function () {
        $.blockUI({
            message: '<i class="icon-spinner icon-spin icon-large"></i> Carregando...',
            baseZ: 1000000,
            centerY: 0,
            showOverlay: true,
            css: { top: '', bottom: '27px', left: '10px' }
        });
    },

    unblockUI: function () {
        $.unblockUI();
    },

    jsonToQueryURL: function (json) {
        var query = '';
        for (var index in json) {
            if (index != 'errors' && index != 'isValid' && index != 'isAnyMessageShown') {
                if (json[index] != undefined) {
                    if (/^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/.test(json[index])) {
                        json[index] = moment(json[index], 'DD/MM/YYYY').format('YYYY-MM-DD');
                    }
                    if (/^[0-9]{2}\/[0-9]{2}\/[0-9]{4} [0-9]{2}:[0-9]{2}$/.test(json[index])) {
                        json[index] = moment(json[index], 'DD/MM/YYYY HH:mm').format('YYYY-MM-DD HH:mm');
                    }
                    query += index + '=' + json[index] + '&';
                }
            }
        }
        return query;
    },

    loginPopup: {

        __raw: null,

        __ajaxRequests: [],

        __title: 'Sessão Expirada',

        __isShowing: false,

        __init: function () {

            var self = this;

            $.ajax({

                url: ROOT + '/Account/LoginPopup',
                success: function (data) {

                    self.__raw = data;
                },
                error: function () {

                    //alert('error loading login popup');
                }
            });
        },

        show: function () {

            var self = this;

            if (this.__raw !== null && !this.__isShowing) {

                this.__isShowing = true;

                $('#loginPopup').remove();

                var content =
                                '<div class="modal-header">' +
                                '    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>' +
                                '    <h3 id="myModalLabel">' + this.__title + '</h3>' +
                                '</div>' +
                                '<div class="modal-body">' +
                                    this.__raw +
                                    '<div class="alert alert-error text-center hide"></div>' +
                                '</div>' +
                                '<div class="modal-footer">' +
                                '   <a href="javascript: void(0);" class="btn btn-primary login">Login</a>' +
                                '</div>';

                $('body').append('<div id="loginPopup" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' + content + '</div>');

                $('#loginPopup .login').click(function () {

                    $('#loginPopup form').submit();
                });

                $('#loginPopup form').submit(function (e) {

                    e.stopPropagation();
                    e.preventDefault();

                    self.__login();
                });

                $('#loginPopup').modal({ backdrop: 'static', keyboard: false });
            }
        },

        hide: function () {

            this.__isShowing = false;

            $('#loginPopup').modal('hide');
        },

        __login: function () {

            var self = this;

            $.ajax({

                type: 'POST',
                url: ROOT + '/Account/JSONLogin',
                data: 'user=' + $('#UserName').val() + '&password=' + $('#Password').val(),
                success: function (data) {

                    if (data.success) {

                        self.hide();
                        self.__didLogin();
                    }
                    else {

                        $('#loginPopup .alert-error').show().html(data.message);
                    }
                }
            });
        },

        __didLogin: function () {

            for (var i = 0, len = this.__ajaxRequests.length; i < len; i++) {

                $.ajax(this.__ajaxRequests[i]);
            }

            this.__ajaxRequests = [];
        }
    }
}


$(function () {
    controle.init();
});