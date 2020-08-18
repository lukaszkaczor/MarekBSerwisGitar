var flag = true;
var dataArray;

var checkboxes;
var prices;
var totalPrice = 0;
var f2 = false;

$(document).ready(function () {
    $('input[type=radio][name=productId]').change(function () {

        $.get("/Home/GetList", { instrumentId: $(this).val() }, function (data) {
            $("#form").empty();
            dataArray = data;

            $("#form").append('<hr /><h4 style="margin-top: 30px;">2. Wybierz interesujące Cię usługi</h4>');
            $("#form").append('<h5>' + dataArray[0].ServiceTypeName + '</h5>');

            for (var i = 0; i < dataArray.length; i++) {

                if (flag == false) {
                    $("#form").append('<h5 style="margin-top:20px;">' + dataArray[i].ServiceTypeName + '</h5>');
                    flag = true;
                }

                $("#form").append('<div class="form-check" style="margin-left: 2rem">' +
                    '<input class="form-check-input" data-val="true" id="Services_' + i + '__IsChecked" name="Services[' + i + '].IsChecked" type="checkbox" value="true" />' +
                    '<input name="Services[' + i + '].IsChecked" type="hidden" value="false" />' +
                    '<input data-val="true" data-val-required="Pole ServiceId jest wymagane." id="Services_' + i + '__ServiceId" name="Services[' + i + '].ServiceId" type="hidden" value="' + dataArray[i].ServiceId + '" />' +
                    '<label class="form-check-label" for="Services_'+i+'__IsChecked">' + dataArray[i].ServiceName + ' (<span class="price">' + dataArray[i].ServicePrice + '</span>zł)' + '</label>' +
                    '</div>');


                if (i < dataArray.length - 1) {
                    if (dataArray[i].ServiceTypeName != dataArray[i + 1].ServiceTypeName) {
                        flag = false;
                    }
                }
            }
            $("#form").append('<input data-val="true" id="InstrumentId" name="InstrumentId" type="hidden" value="' + dataArray[0].InstrumentId + '" / > ');
            $("#form").append('<div class="form-group" style="margin-top: 30px;">' +
                '<label for= "Message">Inne (cena do uzgodnienia)</label>' +
                '<textarea class="form-control" name="Message" id="Message" rows="3"></textarea></div>');

                $('#form').append('<h4>Cena razem ~ <span class="totalPrice">0</span>zł</h4>')

            if ($('#IsAuthenticated').val()) {
                $("#form").append('<button class="btn btn-success" style="margin: 0 0">Przejdź do koszyka</button>');
            }
            checkboxes = $('.form-check-input');
            prices = $('.price');
            totalPrice = 0;
            $('.totalPrice').text(totalPrice);
            f2 = true;
        });
    });

    $('form').on('click', function () {
        if (f2 == true) {
            totalPrice = 0;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    let price  = parseFloat(prices[i].textContent);
                    totalPrice = totalPrice + price ;
                }
            }
            $('.totalPrice').text(totalPrice);
        }
    });
});

