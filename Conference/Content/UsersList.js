
$("#sortingPropertyInput").change((e) => {
    const propertyId = e.target.value;
    if (propertyId) {
        const request = $.ajax({
            url: "SortedUsers",
            data: {
                propertyId: propertyId
            }
        });

        request.done((content) => $('#usersList').html(content));

        request.fail((jqXHR, textStatus) => alert("Request failed: " + textStatus + ' ' + jqXHR.status));
    } 
});