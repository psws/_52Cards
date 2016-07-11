$(function () {
    window.URL = window.URL || window.webkitURL;


    // Fetch the initial data.
    //var controlUri = '/api/control/';
    var bodyContainer = $("#CardListPanel");
    if (bodyContainer.length  == 0) {
        bodyContainer = $("div.body-content ");
    }

    var updateProgressDiv = $("#updateProgressDiv");
    var tmp = bodyContainer.width();
    var position = bodyContainer.offset();

    var x = position.left + Math.round(bodyContainer.width() / 2) - Math.round(updateProgressDiv.width() / 2);
    var y = position.top + Math.round(bodyContainer.height() / 2) - Math.round(updateProgressDiv.height() / 2);

    //	set the progress element to this position
    updateProgressDiv.css({
        position: "absolute",
        top: y + "px",
        left: x + "px"
    });


    $("button[id^='Card'] ").click(function (e) {
        switch (e.currentTarget.id) {
            case 'CardSort':
                var val = $('#StateLabel');
                $('#StateLabel')[0].innerText = 'The deck is: SORTED';
                _52.SortCards()
                break;
            case 'CardShuffle':
                $('#StateLabel')[0].innerText  = 'The deck is: SHUFFLED';
                _52.ShuffleCards()
                break;
        }

    });

    $("button[id='CardSort'] ").trigger('click');



}); //end of ready

//http://appendto.com/2010/10/how-good-c-habits-can-encourage-bad-javascript-habits-part-1/
(function (_52, $, undefined) {
    _52.dataUri = '/v1/Data';
    _52.CurrentGame = "Bridge";
    _52.ajaxCallCount = 0;

    _52.CardArray = [];






    _52.CardElementDTO =
        {
            DeckId: '',
            CardSuitEnum: 1,
            Value: 0
        }

    _52.imgArray = [];

    _52.imgArray[0] = new Image();
    _52.imgArray[0].src = 'images/clubs.png';
    _52.imgArray[1] = new Image();
    _52.imgArray[1].src = 'images/diamonds.jpg';
    _52.imgArray[2] = new Image();
    _52.imgArray[2].src = 'images/hearts.jpg';
    _52.imgArray[3] = new Image();
    _52.imgArray[3].src = 'images/spade.png';



    _52.SortCards = function () {


        var dataObj = {
            Game: _52.CurrentGame,
            CardElementDTOs: _52.CardArray
        }
         _52.ajaxHelper(_52.dataUri + "/SortCards", 'POST', 'Json', false, dataObj, _52.CardView);
    }

    _52.ShuffleCards = function () {
        var dataObj = {
            CurrevtGame: _52.CurrentGame,
            CardElementDTOs: _52.CardArray
        }
        _52.ajaxHelper(_52.dataUri + "/ShuffleCards", 'POST', 'Json', false, dataObj, _52.CardView);
    }


    _52.CardView = function (CardElementDTOs) {
        _52.CardArray.length = 0;
        var Panel = $('#CardListPanel');

        var OlClrOl = $('#CardListPanel ol ')
            .each(function (indexInArray, valueOfElement) {
                $(this).remove();
        });


        for (var j = 0; j < CardElementDTOs.length; j++) {
            var item = CardElementDTOs[j];
            _52.CardArray.push(item);
        }


        //Vertical LIST
        var i, k;
        var colLiCnt;
        var columnCnt = 4;
        if (CardElementDTOs != null) {

            var TotalCards = CardElementDTOs.length;
            if (TotalCards > 4) {
                colLiCnt = Math.ceil(TotalCards / columnCnt);
            } else {
                colLiCnt = TotalCards;
            }
            var colWidth = Math.floor(100 / columnCnt) + "%";
            var CardIndex = 0;
            var column = 1;


            if (TotalCards != 0) {
                for (var i = 0; i < TotalCards; i += colLiCnt) {
                    Panel.append("<ol id = 'list" + column + "' class='liCol'></ol>");
                    var PanelOl = $("ol[id ='list" + column + "']");
                    for (var k = CardIndex; k < colLiCnt * column; k++) {
                        if (k == TotalCards) {
                            break;
                        }
                        var image =  _52.imgArray[_52.CardArray[k].CardSuitEnum -1].src
                        PanelOl.append('<li value = ' + _52.CardArray[k].Value +'>' +
                                '<div style="float: left;">' +
                                    '<img  src="' + image + '"   >' +
                                     '<div class="liRow">' + _52.CardArray[k].DeckId +
                                 '</div></div>' +
                                 '</li>');
                    }
                    CardIndex += colLiCnt;
                    column++;
                }

            }
            $(".liCol").css("width", colWidth)

        }

    }


    _52.ajaxHelper = function (uri, method, datatype, processdata, data, Function) {
        $.ajax({
            type: method,
            url: uri,
            dataType: datatype,
            processData: processdata,
            contentType: 'application/json',
            beforeSend: function () {
                _52.ajaxCallCount++;
                $('#updateProgressDiv').show();
            },
            complete: function () {
                _52.ajaxCallCount--;
                if (_52.ajaxCallCount == 0) {
                    $('#updateProgressDiv').hide();
                }
            },

            data: data ? JSON.stringify(data) : null,
        })
       .done(Function)
       .fail(function (jqXHR, textStatus, errorThrown) {
           console.log(errorThrown);
       });

    }


}(window._52 = window._52 || {}, jQuery));
