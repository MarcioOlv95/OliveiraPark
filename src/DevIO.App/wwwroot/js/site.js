function AjaxModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    console.log("ajaxModal")

                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });

                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#ListaAvulsos').load(result.url); //Carrega o resultado HTML para a div demarcada
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });

}

function MarcarHorarioAtual() {

    var date = new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0]

    //tirar os segundos
    date = date.substring(0, date.length - 3)

    $("#hrSaida").val(date)
}

$(document).ready(function () {
    $("#msg_box").fadeOut(2500);

    //$('.placa').mask('SSS0A00');

    //$('.cpf').mask('000-000-000-00');

    //$('.valor').mask('000')

    $('[data-toggle="tooltip"]').tooltip()

    $('.placa').on('input', function (evt) {
        $(this).val(function (_, val) {
            return val.toUpperCase();
        });
    });
})

