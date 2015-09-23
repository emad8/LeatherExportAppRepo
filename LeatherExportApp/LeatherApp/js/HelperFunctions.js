

function GetStateByCountry(control, id) {
    ////alert(control.value);
    ////alert(id);
    $.ajax({
        url: "GetStateByCountry",
        data: { CountryCode: control.value },
        dataType: "json",
        type: "POST",
        error: function () {
            ////alert("An error occurred.");
        },
        success: function (data) {
            var items = "";
            items += "<option value=\"\">" + "-Select-" + "</option>";
            $.each(data, function (i, item) {

                items += "<option value=\"" + item.StateCode + "\">" + item.StateName + "</option>";
            });
            var DropdownID = "#" + id + "";
            $(DropdownID).html(items);
            //GetCityByState(document.getElementById(id) ,id.replace("State","City"));
        }
    });
}

function GetAddUpdateDeleteMessegesText(MessageMode) {
    var alertMsg = "";
    switch (MessageMode.toLowerCase()) {
        case "add":
            alertMsg = "Record added successfully!";
            break;
        case "edit":
            alertMsg = "Record updated successfully!";
            break;
        case "delete":
            alertMsg = "Record deleted successfully!";
            break;
        case "alreadyexists":
            alertMsg = "Record exists!";
            break;
        case "addfailed":
            alertMsg = "Record failed to add!";
            break;
        case "editfailed":
            alertMsg = "Record failed to update!";
            break;
        //asim edited 
        case "atleast1":
            alertMsg = "Select atleast one user role";
            break;
        case "userrequired":
            alertMsg = "Please Select User";
            break;
        case "verified":
            alertMsg = "Verified Successfully!";
            break;
        ///////////////       
        default:
            alertMsg = "Record added successfully!";
            break;
    }
    return alertMsg;
}
function GetCityByState(control, id) {
    ////alert(control.value);
    ////alert(id);
    $.ajax({
        url: "GetCitiesByState",
        data: { StateCode: control.value },
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred.");
        },
        success: function (data) {
            var items = "";
            items += "<option value=\"\">" + "-Select-" + "</option>";
            $.each(data, function (i, item) {
                items += "<option value=\"" + item.CityCode + "\">" + item.CityName + "</option>";
            });
            var DropdownID = "#" + id + "";
            $(DropdownID).html(items);
            //GetCountyByCity(document.getElementById(id) ,id.replace("City","County"));
        }
    });
}

function GetCountyByCity(control, id) {

    $.ajax({
        url: "GetCountiesByCity",
        data: { CityCode: control.value },
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred.");
        },
        success: function (data) {
            var items = "";
            items += "<option value=\"\">" + "-Select-" + "</option>";
            $.each(data, function (i, item) {
                items += "<option value=\"" + item.CountyCode + "\">" + item.CountyName + "</option>";
            });
            var DropdownID = "#" + id + "";
            $(DropdownID).html(items);
        }
    });
}

function GetStateByCountryWithValue(control, id, val) {
    ////alert(control.value);
    ////alert(id);
    $.ajax({
        url: "GetStateByCountry",
        data: { CountryCode: control.value },
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred.");
        },
        success: function (data) {
            var items = "";
            items += "<option value=\"\">" + "-Select-" + "</option>";
            $.each(data, function (i, item) {

                items += "<option value=\"" + item.StateCode + "\">" + item.StateName + "</option>";
            });
            var DropdownID = "#" + id + "";
            $(DropdownID).html(items);
            //GetCityByState(document.getElementById(id) ,id.replace("State","City"));

            $(DropdownID).val(val);
        }
    });
}

function GetCityByStateWithValue(control, id, val) {
    //    alert(control.value);
    //    alert(id);
    //    alert(val);
    $.ajax({
        url: "GetCitiesByState",
        data: { StateCode: control.value },
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred.");
        },
        success: function (data) {
            var items = "";
            items += "<option value=\"\">" + "-Select-" + "</option>";
            $.each(data, function (i, item) {
                items += "<option value=\"" + item.CityCode + "\">" + item.CityName + "</option>";
            });
            var DropdownID = "#" + id + "";
            $(DropdownID).html(items);
            //GetCountyByCity(document.getElementById(id) ,id.replace("City","County"));

            $(DropdownID).val(val);
        }
    });
}

function GetCountyByCityWithValue(control, id, val) {
    //alert("GetCountyByCityWithValue");
    $.ajax({
        url: "GetCountiesByCity",
        data: { CityCode: control.value },
        dataType: "json",
        type: "POST",
        error: function () {
            //alert("An error occurred.");
        },
        success: function (data) {
            var items = "";
            items += "<option value=\"\">" + "-Select-" + "</option>";
            $.each(data, function (i, item) {
                items += "<option value=\"" + item.CountyCode + "\">" + item.CountyName + "</option>";
            });
            var DropdownID = "#" + id + "";
            $(DropdownID).html(items);

            $(DropdownID).val(val);
        }
    });
}

function ValidateInteger(Value) {
    var intRegex = /^[\-\+]?\d+$/;
    if (Value == "")
        return true;
    if (intRegex.test(Value)) {
        return true;
    }
    else
        return false;
}

function ValidateNumber(Value) {
    var intRegex = /^[\-\+]?(([0-9]+)([\.,]([0-9]+))?|([\.,]([0-9]+))?)$/;
    if (Value == "")
        return true;
    if (intRegex.test(Value)) {
        return true;
    }
    else
        return false;
}

function ValidateEmail(Value) {
    var intRegex = /^((([a-z]|\d|[!#\$%&*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i;
    if (Value == "")
        return true;
    if (intRegex.test(Value)) {
        return true;
    }
    else
        return false;
}
/*

function getLastPageIndex(j) {
if (j == 1) {
document.getElementById('PageSize').value = document.getElementById('DDLPageSize').value;
$("#DDLPageSize2").val($("#DDLPageSize").val());
}
else if (j == 2) {
document.getElementById('PageSize').value = document.getElementById('DDLPageSize2').value;
$("#DDLPageSize").val($("#DDLPageSize2").val());
}
document.getElementById('LastPageIndex').value = parseInt(document.getElementById('FullPageCount').value) / parseInt(document.getElementById('PageSize').value);
if (parseInt(document.getElementById('FullPageCount').value) % parseInt(document.getElementById('PageSize').value) > 0)
document.getElementById('LastPageIndex').value = parseInt(document.getElementById('LastPageIndex').value) + 1;
var iHTML = "";
ChangePagingIndexes();
}

function ChangePagingIndexes() {
setTimeout(function () {
var CurrentPageIndex = parseInt(document.getElementById('currentPageIndex').value);
var LastPageIndex = parseInt(document.getElementById('LastPageIndex').value);
var iHTML = "";

var firstPageNumber = CurrentPageIndex;
var lastPageNumber = LastPageIndex;
var maxPageNumbersToDisplay = 2;
if (CurrentPageIndex - maxPageNumbersToDisplay > 1)
firstPageNumber = CurrentPageIndex - maxPageNumbersToDisplay;
else
firstPageNumber = 1;
if (LastPageIndex > CurrentPageIndex + maxPageNumbersToDisplay)
lastPageNumber = CurrentPageIndex + maxPageNumbersToDisplay;
else
lastPageNumber = LastPageIndex;

for (i = firstPageNumber; i <= lastPageNumber; i++) {
if (i == CurrentPageIndex)
iHTML = iHTML + "<li style=\"background-color:grey\"><a href='javascript:' onclick='ChangePageIndex(" + i + ")'>" + i + "</a></li>";
else
iHTML = iHTML + "<li><a href='javascript:' onclick='ChangePageIndex(" + i + ")'>" + i + "</a></li>";
}
if (iHTML != "") {
$('#pagesTop').html(iHTML);
$('#pagesBottom').html(iHTML);
}
}, 1000);
}

function Next(Last) {
var arr = GetSearchArray(); //GetSearchArray function is defined on page.
var Current = document.getElementById('currentPageIndex').value;
var LastPage = document.getElementById('LastPageIndex').value;
getLastPageIndex();
if (LastPage != Current) {
$('#loading').show();
var PageSize = 10;
if (document.getElementById('HDPageSizeSelector').value == "1")
PageSize = document.getElementById('DDLPageSize').value;
else
PageSize = document.getElementById('DDLPageSize2').value;
$.ajax({
url: 'Next',
type: 'POST',
data: { currentPageIndex: document.getElementById('currentPageIndex').value, Values: JSON.stringify(arr), NewPageSize: PageSize },
complete: function (result) {
SetGridData(result);    //SetGridData function is defined on page.
document.getElementById('currentPageIndex').value = parseInt(document.getElementById('currentPageIndex').value) + 1;
$('#loading').hide();
},
success: function (result) {
$('#loading').hide();
},
error: function (result) {
}
});    //end ajax
}
ChangePagingIndexes();
}


function Previous() {
var arr = GetSearchArray(); //GetSearchArray function is defined on page.
var Current = document.getElementById('currentPageIndex').value;
if (Current != 1) {
$('#loading').show();
var PageSize = 10;
if (document.getElementById('HDPageSizeSelector').value == "1")
PageSize = document.getElementById('DDLPageSize').value;
else
PageSize = document.getElementById('DDLPageSize2').value;

$.ajax({
url: 'Previous',
type: 'POST',
data: { currentPageIndex: document.getElementById('currentPageIndex').value, Values: JSON.stringify(arr), NewPageSize: PageSize },
complete: function (result) {
SetGridData(result);    //SetGridData function is defined on page.
document.getElementById('currentPageIndex').value = parseInt(document.getElementById('currentPageIndex').value) - 1;
$('#loading').hide();
},
success: function (result) {
$('#loading').hide();
},
error: function (result) {
////alert('1');
}
});   //end ajax

}
ChangePagingIndexes();
}

function ChangePageByNumber(i) {
    
document.getElementById('currentPageIndex').value = "1";
getLastPageIndex(i);
ChangePageIndex(document.getElementById('currentPageIndex').value);
ChangePagingIndexes();
}

function ChangePageIndex(newIndex) {
    
//if(newIndex != 1)
//newIndex = document.getElementById('LastPageIndex').value;
if (newIndex == -2)
newIndex = document.getElementById('LastPageIndex').value;
var arr = GetSearchArray(); //GetSearchArray function is defined on page.
$('#loading').show()
document.getElementById('currentPageIndex').value = newIndex;
var PageSize = 10;
if (document.getElementById('HDPageSizeSelector').value == "1")
PageSize = document.getElementById('DDLPageSize').value;
else
PageSize = document.getElementById('DDLPageSize2').value;
$.ajax({
url: 'ChangePageByNumber',
type: 'POST',
data: { newPageIndex: document.getElementById('currentPageIndex').value, Values: JSON.stringify(arr), NewPageSize: PageSize },
complete: function (result) {
SetGridData(result);    //SetGridData function is defined on page.
$('#loading').hide()
},
success: function (result) {
$('#loading').hide();
},
error: function (result) {
}
});   //end ajax
ChangePagingIndexes();
}

function RedirectToLocation(control, location) {

////alert(location);
//location = 'yahoo.com';




}

function paste(obj) {
alert(obj);
var totalCharacterCount = window.clipboardData.getData('MainContent_tbTollNo');
alert(totalCharacterCount);

var strValidChars = "0123456789";
var strChar;
var FilteredChars = "";
for (i = 0; i < totalCharacterCount.length; i++) {
strChar = totalCharacterCount.charAt(i);
if (strValidChars.indexOf(strChar) != -1) {
FilteredChars = FilteredChars + strChar;
}
}
obj.value = FilteredChars;
return false;
}
*/




//----------------- By FARHAN ------------------//


// For Phone And Fax Number
function Phone(evt) {

    var specialKeys1 = new Array();
    specialKeys1.push(43); //+ Sign


    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode > 32 && specialKeys1.indexOf(evt.charCode) == -1) && (charCode < 48 || charCode > 57)) {
        return false;
    }

}
// Allow Like MR.ABC
function Title(evt) {

    var specialKeys1 = new Array();
    specialKeys1.push(8); // BackSpace
    specialKeys1.push(32); //space
    specialKeys1.push(46); //DOT


    evt = (evt) ? evt : window.event;
    var keyCode = (evt.which) ? evt.which : evt.keyCode;
    if (keyCode == 8 || keyCode == 32 || keyCode == 46) {
        return true;
    }

    if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123))
        return false;


}






//for Longitude Latitude
function Dimension(evt) {


    var specialKeys1 = new Array();
    specialKeys1.push(46); //DOT


    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 32 && specialKeys1.indexOf(evt.charCode) == -1 && (charCode < 48 || charCode > 57)) {
        return false;
    }

}




// OnLy For Numbers
function OnlyNumbers(evt) {
    
    var charCode = (evt.which) ? evt.which : event.keyCode;

    if (charCode > 32 && (charCode < 48 || charCode > 57))
    { return false; }
    else {
        return true;
    }
}
function Onlyfloat(evt, obj) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode == 46) {
        if (isNaN(obj.value + '.')) {
            return false;
        }
        else return true;
    }
    else if (charCode >= 32 && (charCode < 48 || charCode > 57))
    {
        return false;
    }
    else {
        return true;
    }
}
/// for submit
function Enter(event) {
    //var keyCode = (event.which) ? event.which : event.keyCode;
    if (event.keyCode == 13) {
        $("#btnSubmit").click();
    }
}

//  For Fax/Ph Number
//function Phone(evt) {
//    var charCode = (evt.which) ? evt.which : event.keyCode;
//    if (charCode == 37 && charCode == 39 && charCode > 32 && (charCode < 40 || charCode > 57)) {
//        return false;
//    }
//    return true;
//}

// Only For Alhphabatic
function OnlyAlhpabats(evt) {
    var keyCode = (evt.which) ? evt.which : evt.keyCode;
    if (keyCode != 9 && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && (keyCode != 32 && keyCode != 8))
        return false;


}

// For AlphaNumeric
function checkAlphaNumeric(evt) {


    var keyCode = (evt.which) ? evt.which : evt.keyCode;
    if (keyCode != 8 && keyCode != 37 && keyCode != 39 && (keyCode < 65 || keyCode > 90) && (keyCode < 48 || keyCode > 57) && (keyCode < 97 || keyCode > 123) && keyCode != 32 && keyCode != 40)
        return false;




}


// Specially For Application to Send Out --- >   Accept Alphanumeric without First Letter Number.!
function AcceptAlphabatWithOutFirstNumber(evt, val) {

    var keyCode = (evt.which) ? evt.which : evt.keyCode;
    if (val.value.length == 0) {

        if (keyCode == 32) {
            return false;
        }

        if (keyCode != 8 && keyCode != 39 && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
            return false;

    }

    if (val.value.length != 0) {


        if (keyCode != 8 && keyCode != 39 && (keyCode < 65 || keyCode > 90) && (keyCode < 48 || keyCode > 57) && (keyCode < 97 || keyCode > 123) && keyCode != 32 && keyCode != 40)
            return false;

    }
}



function StringWithSpace(controlName) {
    //var validRegEx = /^[A-Za-z\d\s]+$/;
    var validRegEx = /^[A-Za-z0-9][A-Za-z-9, .+-_&#'"]+$/;
    var validString = controlName.value.match(validRegEx);
    if (validString == null) {
        return false;
    }
    else {
        return true;
    }
}
function checkEmail(id) {

    var email = document.getElementById(id);
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!filter.test(id)) {


        return false;
    }


    function GetCorrectDateFormat(_date) {

        if (_date != null && _date != "undefined") {
            var d = new Date(parseInt(_date.substr(6)));
            var StartDate1 = (d.getMonth() + 1) + "/" + (d.getDate()) + "/" + d.getFullYear();
            return StartDate1;
        }
        return "";
    }
    function GetSelectedValue(control) {
        var selected = $('#<%= "' + control + '" %> input:checked').val();
        return selected;
    }

    function EmptyDropDownList(ID, Text, Value) {

        $("select[id$=" + ID + "] > option").remove();
        $('#' + ID + '').append(new Option(Text, Value));
    }

    function GetStateAndCityByZipcode2(Zip, State, City) {
        if (Zip.value.length < 5)
            return;
        $('#loadingPopup').show();
        $.ajax({
            url: '/Client/GetStateAndCityByZipcode',
            type: 'POST',
            data: { Zipcode: Zip.value },
            complete: function (result) {
                var objt = jQuery.parseJSON(result.responseText);
                if (objt != null) {
                    document.getElementById(State).value = objt.StateCode;
                    setTimeout(function () {
                        GetCityByStateWithValue(document.getElementById(State), City, objt.CityCode);
                    }, 500);
                }
                else {
                    return false;
                }
                $('#loadingPopup').hide();
            },
            success: function (result) {
                $('#loadingPopup').hide();
            },
            error: function (result) {
                /*alert(result.responseText);*/
            }
        }); //end ajax
    }

}