function setup() { }
var viewurlitem = document.getElementById('ViewUrlItem').value;

class Item {
    constructor(id, title, tags, countlike) {
        let container = select('#items');
        //this.coldiv = createDiv('').addClass('col').parent(container);
        this.carddiv = createDiv('').addClass('card').parent(container).id(id);
        this.cardBody = createDiv('').addClass('card-body').parent(this.carddiv);
        this.fillcardbody(title, tags, countlike);
        this.cardFooter = createDiv('').addClass('card-footer').parent(this.carddiv);
        this.fillcardfooter(id);
        this.addbuttonevents();
    }
    fillcardbody(title, tags, countlike) {
        this.title = createElement('h5').addClass('card-title').html(title).parent(this.cardBody);
        this.topic = createElement('h6').addClass('card-title').html('Tags: '+ gettags(tags)).parent(this.cardBody);
        this.likes = createElement('h7').addClass('card-text').html('Likes '+countlike).parent(this.cardBody);
    }
    fillcardfooter(id) {
        this.buttonv = createA('#', 'Open').addClass('btn btn-primary').parent(this.cardFooter);
    }
    addbuttonevents(flag) {
        this.buttonv.elt.addEventListener('click', () => {
            location.href = viewurlitem.replace('__id__', this.carddiv.id());
        })
    }
}

function CreateItemCard(id, title, tags, countlike) {
    let i = new Item(id, title, tags, countlike);
}

function gettags(tags) {
    console.log(tags)
    var html = []
    for (var i = 0; i < tags.length; i++) {
        html.push(tags[i].Name)
    }
    if (!html[0]) {
        html = []
        for (var i = 0; i < tags.length; i++) {
            html.push(tags[i].name)
        }
    }
    return html.join(', ')
}