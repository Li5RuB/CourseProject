function dropimage(classDrop,imgurl) {
    select('.' + classDrop).drop((file) => {
        select('.' + classDrop).elt.src = 'https://i.gifer.com/g0R5.gif'
        var form = new FormData();
        form.append("image", file.file)
        $.ajax({
            type: 'POST',
            url: "https://api.imgbb.com/1/upload?key=645730bb8c8c0f5bee63e0e27f420755",
            data: form,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                select('.' + classDrop).elt.src = data.data.url;
                select('.' + imgurl).elt.value = data.data.url;
            }
        });
    })
}
function setup() {
}

function draw() {
}