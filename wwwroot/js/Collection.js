function setup() { }
try {
    var editurl = document.getElementById('EditUrl').value;
} catch {}
var viewurl = document.getElementById('ViewUrl').value;
var defaultimg = "https://www.smartdatajob.com/images/joomlart/demo/default.jpg";
    
class Collection { 
    constructor(id, title, topic, description, urlimg,flag) {
        let container = select('#collections');
        this.coldiv = createDiv('').addClass('col').parent(container);
        this.carddiv = createDiv('').addClass('card').parent(this.coldiv).id(id);
        this.img = createImg(urlimg).addClass('card-img-top imgcard').parent(this.carddiv);
        this.img.elt.addEventListener('error', () => {
            this.img.elt.src = defaultimg;
        })
        this.cardBody = createDiv('').addClass('card-body').parent(this.carddiv);
        this.fillcardbody(title, topic, description);
        this.cardFooter = createDiv('').addClass('card-footer').parent(this.carddiv);
        this.fillcardfooter(id,flag);
        this.addbuttonevents(flag);
    }

    fillcardbody(title, topic, description) {
        this.title = createElement('h5').addClass('card-title').html(title).parent(this.cardBody);
        this.topic = createElement('h7').addClass('card-title').html(topic).parent(this.cardBody);
        this.description = createElement('p').addClass('card-text').html(description).parent(this.cardBody);
    }

    fillcardfooter(id,flag) {
        this.buttonv = createA('#', 'View').addClass('btn btn-primary').parent(this.cardFooter);
        if (flag) {
            this.buttone = createA('#', 'Edit').addClass('btn btn-warning').parent(this.cardFooter);
            this.buttonr = createA('#', 'Remove').addClass('btn btn-secondary').parent(this.cardFooter);
        }
    }

    addbuttonevents(flag) {
        this.buttonv.elt.addEventListener('click', () => {
            location.href = viewurl.replace('__id__', this.carddiv.id());
        })
        if (flag) {
            this.buttone.elt.addEventListener('click', () => {
                location.href = editurl.replace('__id__', this.carddiv.id());
            })
            this.buttonr.elt.addEventListener('click', () => {
                var id = this.carddiv.id();
                var object = this.elt;
                $.ajax({
                    url: 'Collection/Delete/',
                    type: 'DELETE',
                    data: { 'id': id },
                    success: function (result) {
                        $(result).remove()
                    }
                })
            })
        }
    }
}

function CreateCollCard(id, title, topic, description, urlimg,flag) {
    let coll = new Collection(id, title, topic, description, urlimg,flag);
}