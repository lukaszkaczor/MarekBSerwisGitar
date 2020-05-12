var flag = true;
var dataArray;
$(document).ready(function () {
    $("#Instrument_InstrumentId").change(function () {

        $.get("/Home/GetList", { instrumentId: $("#Instrument_InstrumentId").val() }, function (data) {
            $("#form").empty();
            dataArray = data;

            $("#form").append('<h4 style="margin-top: 30px;">2. Wybierz interesujące Cię usługi</h4>');
            $("#form").append('<h5>' + dataArray[0].ServiceTypeName + '</h5>');

            for (var i = 0; i < dataArray.length; i++) {

                if (flag == false) {
                    $("#form").append('<h5 style="margin-top:20px;">' + dataArray[i].ServiceTypeName + '</h5>');
                    flag = true;
                }

                $("#form").append('<div class="form-check" style="margin-left: 2rem">' +
                    '<input class="form-check-input" data-val="true" id="Services_' + i + '__IsChecked" name="Services[' + i + '].IsChecked" type="checkbox" value="true" />' +
                    '<input name="Services[' + i + '].IsChecked" type="hidden" value="false" />)' +
                    '<input data-val="true" data-val-required="Pole ServiceId jest wymagane." id="Services_' + i + '__ServiceId" name="Services[' + i + '].ServiceId" type="hidden" value="' + dataArray[i].ServiceId + '" />' +
                    '<label class="form-check-label" for="Services_'+i+'__IsChecked">' + dataArray[i].ServiceName + ' (' + dataArray[i].ServicePrice + 'zł)' + '</label>' +
                    '</div>');


                if (i < dataArray.length - 1) {
                    if (dataArray[i].ServiceTypeName != dataArray[i + 1].ServiceTypeName) {
                        flag = false;
                    }
                }
            }
            $("#form").append('<input data-val="true" id="InstrumentId" name="InstrumentId" type="hidden" value="' + dataArray[0].InstrumentId + '" / > ');
            //$("#form").append('<div class="form-group" style="margin-top: 30px;">' +
            //    '<label for= "serviceDescription">Inne (cena do uzgodnienia)</label>' +
            //    '<textarea class="form-control" name="serviceDescription" id="serviceDescription" rows="3"></textarea></div>');
            $("#form").append('<button class="btn btn-success">Przejdź do koszyka</button>');
        });
    });

});