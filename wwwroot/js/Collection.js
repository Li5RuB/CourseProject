function setup() {}

var defaultimg = "https://www.smartdatajob.com/images/joomlart/demo/default.jpg";
    
class Collection {
    constructor(id, title, topic, description, urlimg) {
        let container = select('#collections');
        this.carddiv = createDiv('').addClass('card').parent(container).id(id);
        this.img = createImg(urlimg).addClass('card-img-top imgcard').parent(this.carddiv);
        this.img.elt.addEventListener('error', () => {
            this.img.elt.src = defaultimg;
        })
        this.cardBody = createDiv('').addClass('card-body').parent(this.carddiv);
        this.fillcardbody(title, topic, description);
        this.cardFooter = createDiv('').addClass('card-footer').parent(this.carddiv);
        this.fillcardfooter(id);
        this.addbuttonevents();
    }

    fillcardbody(title, topic, description) {
        this.title = createElement('h5').addClass('card-title').html(title).parent(this.cardBody);
        this.topic = createElement('h7').addClass('card-title').html(topic).parent(this.cardBody);
        this.description = createElement('p').addClass('card-text').html(description).parent(this.cardBody);
    }

    fillcardfooter(id) {
        this.buttonv = createA('#', 'Viewing').addClass('btn btn-primary').parent(this.cardFooter);
        this.buttone = createA('#', 'Edit').addClass('btn btn-warning').parent(this.cardFooter);
        this.buttonr = createA('#', 'Remove').addClass('btn btn-secondary').parent(this.cardFooter);
    }

    addbuttonevents() {
        this.buttonv.elt.addEventListener('click', () => {
            console.log('clickv ' + this.carddiv.id())
        })
        this.buttone.elt.addEventListener('click', () => {
            console.log('clicke ' + this.carddiv.id())
        })
        this.buttonr.elt.addEventListener('click', () => {
            console.log('clickr ' + this.carddiv.id())
        })
    }
}

function CreateCollCard(id, title, topic, description, urlimg) {
    let coll = new Collection(id, title, topic, description, urlimg);
}