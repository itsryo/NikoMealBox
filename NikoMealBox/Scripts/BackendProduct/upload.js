var feedback = function(res) {
    if (res.success === true) {
        var get_link = res.data.link.replace(/^http:\/\//i, 'https://');
        document.querySelector('.status').classList.add('bg-success');
        document.querySelector('.status').innerHTML =
            'Image : ' + '<br><input class="image-url" value=\"' + get_link + '\"/>' + '<img class="img" alt="Imgur-Upload" src=\"' + get_link + '\"/>';

        document.querySelector('.testimg').innerHTML =
            '<img src=\"' + get_link + '\" style="margin:10px" height="200" width="200" id="imagePreview" />'
            + '<input type="file" name="ImageUpload" id="ImageUpload" value=\"' + get_link + '\" accept="image/jpeg,image/png")" />';
        document.querySelector('#ImageUpload').setAttribute("onchange", "ShowImagePreview(this, document.getElementById('imagePreview'))");

    }
};

new Imgur({
    clientid: '8b1721cd18c1965', //You can change this ClientID
    callback: feedback
});