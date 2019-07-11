


<form id="uploader">
    <input type="text"  id="deneme"  />
    <input id="fileInput" type="file" multiple>
    <input type="submit" value="Upload file"/>
</form>


<script>
    document.getElementById('uploader').onsubmit = function () {
        var formdata = new FormData(); 
        var fileInput = document.getElementById('fileInput');
        var name = $("#deneme").val();
        for (i = 0; i < fileInput.files.length; i++) {
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }
        formdata.append("Deneme",name);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'ControllerName/Upload');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                alert(xhr.responseText);
            }
        }
        return false;
    }
</script>
//------------
//CONTROLLER
    public JsonResult Upload()
        {


            string degisken=Request.Form["Deneme"].ToString();

        if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
            }
			string result="success";

            return Json(result);
}




//-----------------
////WITHOUT AJAX
///  
@using (Html.BeginForm("KariyerForm", "Kurumsal", new {dil = dil}, FormMethod.Post, new {enctype = "multipart/form-data"}))
{

<form>
<div class="form-group">
<input type = "text" placeholder="Ad Soyad" name="ad" id="adsoyad" class="form-control">
</div>
<div class="form-group">
<input type = "email" placeholder="E-mail" name="email" id="email" class="form-control">
</div>
<div class="form-group">
<label for="dosya_ekle" class="label-cv"><i class="fa fa-upload"></i>Dosya Ekle</label>
<input type = "file" name= "file" class="form-control-file" id="dosya_ekle" style="display: none;">
<input type = "hidden" value="" name="dosya" id="dosya">
</div>
<div class="form-group">
<input type = "submit" class="formbtn" id="gonder" value="Gönder">
</div>
</form>
}