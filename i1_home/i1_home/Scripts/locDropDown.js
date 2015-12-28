    function GetCity(_stateId) {
        $("#Cities").html(null);
        var item = "<option value='0'>Select City</option>";
        var select = $('#Cities');
        $("#Cities").html(item);
        var url = "/Account/GetCityListFromDB";
        document.getElementById("Temp2").value = $('#States option:selected').text();
        $.ajax({
            url: url,
            data: { stateid: _stateId },
            cache: false,
            type: "POST",
            dataType: 'json',
            success: function (data) {
                //debugger;
                $.each(data.CityList, function (i, itemData) {
//                    alert("key : " + i + "data : " + itemData);
                    select.append($('<option/>', {
                        value: itemData,
                        text: itemData
                    }));
                })
            },
            error: function (reponse) {
                alert("error : " + reponse);
            }
        });
    }

    function GetState(_countryId) {
        var url = "/Account/GetStateListFromDB";
        document.getElementById("Temp").value = $('#Country option:selected').text();
        //alert("con = " + $('#Country option:selected').text());
        $.ajax({
            url: url,
            data: { countryid: _countryId },
            cache: false,
            type: "POST",
            dataType: 'json',
            success: function (data) {
                //debugger;
                $("#States").html(null);
                var item = "<option value='0'>Select State</option>";
                var select = $('#States');
                $("#States").html(item);
                
                $.each(data.StateList, function (i, itemData) {
                    // alert("key : " + itemData + " i : "+ i + " data : " + data.StateName[itemData]);
                    select.append($('<option/>', {
                        value: itemData.id,
                        text: itemData.name
                    }));
                })
            },
            error: function (reponse) {
                alert("error : " + reponse);
            }
        });

    }