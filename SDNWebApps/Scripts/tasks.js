
    
    $(document).ready(function () {
        $('a.delete-link').click(OnDeleteClick);
        $('a.got-link').click(OnGotClick);
        $('a.add-link').click(OnAddClick);
    });

function OnDeleteClick(e)
{
    var rowdel = document.getElementById('FullItem{' + e.target.id + '}');
    rowdel.parentNode.removeChild(rowdel);

    $.post("/Tasks/OurTasks/DeleteItem", { taskID: e.target.id },
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

function OnGotClick(e) {

    var done = true;
    var itemID = event.currentTarget.id;

    var div = document.getElementById('FullItem{' + itemID + '}');

    div.parentNode.removeChild(div);


    //need a find a better way
    if (window.location.href.indexOf('showAll=True') < 0)
        hasItem = true;
    else {
        hasItem = false;
    }

    $.post("/Tasks/OurTasks/GotTask/", { id: itemID }, function (data) { });
  
    return false; // for the button
}

function OnAddClick(e) {
    var title = $("#Title").val();
    var duedate = $("#DueDate").val();
    var personID = $("#PersonID").val();
    
    //if (storeid.length == 0)
    //    storeid = 3;

    $.post("/Tasks/Tasks/AddTask", { Title: title, DueDate: duedate, PersonID: personID},
          function (data) { });
    document.getElementById('TaskAdded').innerHTML = title + " was added.";
    document.getElementById('Title').value = "";
    document.getElementById('DueDate').value = "";
    //document.getElementById('SelectedItemId')[1].selected = true;
}