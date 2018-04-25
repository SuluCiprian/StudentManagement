// Write your JavaScript code.

function selectMethod(selectId, text) {
    $("#" + selectId).append('<option value="' + text + '">' + text + '</option>');
    $("#" + selectId + " option").prop('selected', true);
}


$("#addDateButton").click(function () {
    var dateValue = document.getElementById("dateId").value;
    selectMethod("occurenceSelect", dateValue);
});

