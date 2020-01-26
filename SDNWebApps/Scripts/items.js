
    
    $(document).ready(function () {
        $('a.delete-link').click(OnDeleteItemClick);
        $('span.got-link').click(OnGotClick);
        $('a.add-item-link').click(OnAddItemClick);
    });



function OnGotClick(e) {

    var hasItem;
    var itemID = e.target.id;
    
    var div = document.getElementById('FullItem{' + itemID + '}');
    div.innerHTML = "";
    
    //need a find a better way
    if (window.location.href.indexOf('showAll=True') < 0)
        hasItem = true;
    else {
        hasItem = false;
    }

    var url = $(this).data('request-url');
    //console.log(url);
    $.post(url, { itemID: itemID, haveItem: hasItem }, function (data) {


    });

}

function OnAddItemClick(e) {
    var name = $("#Name").val();
    var price = $("#Price").val();
    var storeid = $("#SelectedItemId").val();
    var image = $("#Image")[0].value;

    if (storeid.length == 0)
        storeid = 3;
    var url = $(this).data('request-url');
    $.post("/SDNWebApps/GroceryList/Items/AddItem", { name: name, price: price, StoreID: storeid, uploadFile: image },
          function (data) { });
    document.getElementById('ItemAdded').innerHTML = name + " was added.";
    document.getElementById('Name').value = "";
    document.getElementById('Price').value = "";
    document.getElementById('SelectedItemId')[1].selected = true;
}