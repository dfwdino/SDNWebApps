///


$(document).ready(function () {
    $(document).delegate('a.add-store-link', 'click', OnAddClick);
    $(document).delegate('a.delete-store-link', 'click', OnDeleteClick);
    });

function OnAddClick(e) {
    var name = $("#StoreName").val();
        
    $.post("/GroceryList/Stores/AddStore", { storeName: name},
          function (data) // success
          {
              alert('tea');
          },
          function (msg) // error
          {
              alert('Error');
          }
         );
    document.getElementById('ItemAdded').innerHTML = name + " was added.";
    document.getElementById('StoreName').value = "";
        
}

function OnDeleteClick(e)
{   
    var itemID = e.target.parentElement.id;
    
    var div = document.getElementById(itemID);
    if (div == null)
        return; //fix for double call on .on and .click
    div.parentNode.removeChild(div);

    $.post("/GroceryList/Stores/DeleteStore", { itemID: e.target.id },
          function (result) // success
          {
              alert('success');
          },
          function (result) // error
          {
              alert('error');
          }
         );
    return false; // for the button
}
