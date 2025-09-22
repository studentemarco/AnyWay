const toggleButton = document.getElementById('toggleSidebar')
const sidebar = document.getElementById('sidebar');
const main = document.getElementById('main');
const tbs = document.getElementsByClassName('toolbar')

toggleButton.addEventListener('click', () => {
    sidebar.classList.toggle('hidden');
    main.classList.toggle('expanded');
    
    if (sidebar.classList.contains('hidden')) {
        toggleButton.style.left = '1.5rem';
    } else {
        toggleButton.style.left = 'calc(var(--sidebar-width) + 1.5rem)';
    }
});

// Gestione mappa nel canvas

let MIN_SIZE = 300
let MAX_SIZE = 100000000000
let BASE_RADIUS = 1500
let BASE_LINE_WIDTH = 600
let BASE_FONT_SIZE = 1500;

const canvas = document.getElementById('canva')
const ctx = canvas.getContext('2d');

canvas.addEventListener('transitionend', () => {
    isAnimating = false;
});

let currentMapData = {
    points: [],
    floors: [],
};

let currentFloorData = {
    points: [],
    name: null,
    floor: null,
    image: null,
    path: null,
};

currentIndexFloor = 0;
let currentStep = 0;

let path = {
    sequence: null,
}

// Variabili gestione animazioni
let isAnimating = false;
let currentTransform = {
    x: canvas.width / 2,
    y: canvas.height / 2,
    scale: 1,
    rotation: 0
};
let targetTransform = { ...currentTransform };
let animationFrameId = null;

loadMap();

function clearAll()
{
    currentMapData = {
        points: [],
        floors: [],
    };
    
    currentFloorData = {
        points: [],
        name: null,
        floor: null,
        image: null,
        path: null,
    };
    
    currentIndexFloor = 0;
    currentStep = 0;
    
    path = {
        sequence: null,
    }
    
    // Variabili gestione animazioni
    isAnimating = false;
    currentTransform = {
        x: canvas.width / 2,
        y: canvas.height / 2,
        scale: 1,
        rotation: 0
    };
    targetTransform = { ...currentTransform };
    animationFrameId = null;
}
function clearCanvas() {
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.clearRect(0, 0, canvas.width, canvas.height);
}

async function loadImage(url) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => resolve(img);
        img.onerror = reject;
        img.src = url;
    });
}

function drawImage(img) {
    canvas.width = img.width;
    canvas.height = img.height;
    ctx.drawImage(img, 0, 0);
}

async function loadMap() {
    clearCanvas()
    clearAll()
    hideFloorChangeAlert()
    const id = document.body.dataset.id;

    console.log(id);

    try {
        const [floorsRes, pointsRes] = await Promise.all([
            fetch(`/floorsJson/?id=${id}`),
            fetch(`/pointsJson/?id=${id}`),
            //fetch(`/arcsJson/?id=${id}`)
        ])

        currentMapData.floors = await floorsRes.json();
        currentMapData.points = await pointsRes.json();

        populateDropdowns();

        if (!floorsRes.ok) {
            throw new Error('Errore nel caricamento dei dati della mappa: floors');
        }
        if (!pointsRes.ok) {
            throw new Error('Errore nel caricamento dei dati della mappa: points');
        }

        await loadFloorData(currentIndexFloor);
        loadFloor();
        Step(0);

        Array.from(tbs).forEach(element => {
            element.classList.add('active');
        });

        document.getElementById('errorMessage').style.display = 'none';
    } catch (error) {
        Array.from(tbs).forEach(element => {
            element.classList.remove('active');
        });
        console.log(error)
        document.getElementById('errorMessage').style.display = 'block';
    }
}

async function loadFloorData(fl) {
    if (currentMapData.floors.length === 0) {
        trhow(new Error("Nessun piano trovato"))
        return;
    }
    if (fl < 0 || fl > currentMapData.floors.length) {
        trhow(new Error("given floor is out of range"))
        return;
    }


    console.log(currentMapData.floors[fl])
    currentFloorData.name = currentMapData.floors[fl].name
    currentFloorData.points = currentMapData.points.filter(p => p.floor === currentMapData.floors[fl].floor)
    const imageUrl = `/map_image/?id=${document.body.dataset.id}&floor=${currentMapData.floors[fl].floor}`;
    currentFloorData.image = await loadImage(imageUrl)
    currentFloorData.floor = currentMapData.floors[fl].floor;
    canvas.width = currentFloorData.image.width;
    canvas.height = currentFloorData.image.height;

    currentTransform = {
        x: canvas.width / 2,
        y: canvas.height / 2,
        scale: 1,
        rotation: 0
    };

    MIN_SIZE = 300 * ((canvas.width + canvas.height) / 2) / 7000;
    MAX_SIZE = 5000 * ((canvas.width + canvas.height) / 2) / 7000;
    BASE_RADIUS = 10 * ((canvas.width + canvas.height) / 2) / 7000;
    BASE_LINE_WIDTH = 30 * ((canvas.width + canvas.height) / 2) / 7000;
    BASE_FONT_SIZE = 15;
}

async function loadImage(url) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => resolve(img);
        img.onerror = reject;
        img.src = url;
    });
}


function drawImage(img) {
    console.log(img)
    ctx.drawImage(img, 0, 0);
}

function populateDropdowns() {
    const startSelect = document.getElementById('partenza');
    const endSelect = document.getElementById('arrivo');

    // Pulisci le opzioni esistenti mantenendo il placeholder
    startSelect.innerHTML = '<option value="" disabled selected>Punto di partenza</option>';
    endSelect.innerHTML = '<option value="" disabled selected>Punto di arrivo</option>';

    // Popola con i punti della mappa
    currentMapData.points.forEach(point => {
        const option = document.createElement('option');
        option.value = `${point.floor}*${point.name}`;
        option.textContent = `${point.name} (${point.floor})`;

        startSelect.appendChild(option.cloneNode(true));
        endSelect.appendChild(option.cloneNode(true));
    });
}

function drawPoints(points) {
    const displayedRect = canvas.getBoundingClientRect();
    const cssScale = canvas.width / displayedRect.width;
    const totalScale = currentTransform.scale * cssScale;

    console.log("MIN", MIN_SIZE)

    // Calcolo limiti dinamici
    const dynamicMin = MIN_SIZE / totalScale;
    const dynamicMax = MAX_SIZE / totalScale;

    points.forEach(point => {
        const [x, y] = point.cordinatepunti.split(',').map(coord => parseInt(coord.trim()));
        ctx.beginPath();
        ctx.fillStyle = 'Green';

        // Calcolo raggio grezzo
        let radius = (BASE_RADIUS / cssScale) * currentTransform.scale;

        // Applica limiti dinamici
        radius = Math.min(dynamicMax, Math.max(dynamicMin, radius));

        ctx.arc(x, y, radius, 0, Math.PI * 2);
        ctx.fill();

        // Testo con limiti dinamici
        let fontSize = (BASE_FONT_SIZE / cssScale) * currentTransform.scale;
        fontSize = Math.min(dynamicMax, Math.max(dynamicMin, fontSize));
        ctx.font = `${fontSize}px Arial`;
        ctx.fillText(point.name, x + radius + 5, y - radius - 5);
    });
}

function loadFloor() {
    console.log("chiamatooo");
    try {
        ctx.save();
        drawImage(currentFloorData.image);
        drawPoints(currentFloorData.points);
        if (path.sequence && path.sequence.length > 1) {
            DrawThisFloorPath();
        }
    } catch (error) {
        console.error("Errore nel loadFloor:", error);
    } finally {
        ctx.restore();
    }
}

async function findPath() {
    const idMap = document.body.dataset.id;
    const start = document.getElementById('partenza').value;
    const end = document.getElementById('arrivo').value;
    let acc = document.getElementById('accessible').checked;

    console.log(acc);

    if (!idMap || !start || !end) {
        alert('Per favore, inserisci ID mappa e seleziona partenza e arrivo.');
        return;
    }

    try {
        const response = await fetch(`/travel/?IDmap=${idMap}&start=${start}&end=${end}&RA=${acc}`);
        if (!response.ok) {
            const errorData = await response.text();
            let message = JSON.parse(errorData).detail
            throw new Error((message || 'Errore sconosciuto dal server'))
        }
        path.sequence = await response.json();
    } catch (error) {
        console.error('Errore:', error);
        alert(error);
    }
}

async function Navigate() {
    hideFloorChangeAlert()
    clearCanvas();
    await findPath();
    loadFloor();
    Step(0);

}

function ReloadThisFloorPath() {
    const currentFloor = currentFloorData.floor;
    currentFloorData.path = path.sequence
        .filter(point => parseInt(point.split('*')[0]) === currentFloor)
        .map(point => point.split('*')[1]);
}

async function DrawThisFloorPath() {
    await ReloadThisFloorPath();
    if (currentFloorData.path.length > 1) {
        drawPath(currentFloorData.path, currentFloorData.points);
    }
}

function drawPath(path, points) {
    const displayedRect = canvas.getBoundingClientRect();
    const cssScale = canvas.width / displayedRect.width;
    const totalScale = currentTransform.scale * cssScale;

    // Calcolo limiti dinamici
    const dynamicMin = MIN_SIZE / totalScale;
    const dynamicMax = MAX_SIZE / totalScale;

    ctx.beginPath();
    ctx.strokeStyle = 'rgba(0, 127, 255, 0.5)';

    let lineWidth = (BASE_LINE_WIDTH / cssScale) * currentTransform.scale;
    lineWidth = Math.min(dynamicMax, Math.max(dynamicMin, lineWidth));
    ctx.lineWidth = lineWidth;

    path.forEach((pointName, i) => {
        const point = points.find(p => p.name === pointName);
        const [x, y] = point.cordinatepunti.split(',').map(Number);
        i === 0 ? ctx.moveTo(x, y) : ctx.lineTo(x, y);
    });

    ctx.stroke();
}




async function floorUp() {
    hideFloorChangeAlert()
    if (currentIndexFloor < currentMapData.floors.length) {
        currentIndexFloor += 1;
        await loadFloorData(currentIndexFloor)
        loadFloor()
        Step(0);
        setCS(0);
        document.getElementById("floor-label").textContent = currentMapData.floors[currentIndexFloor].floor
    }
}

async function floorDown() {
    hideFloorChangeAlert()
    if (currentIndexFloor > 0) {
        currentIndexFloor -= 1;
        await loadFloorData(currentIndexFloor)
        loadFloor()
        Step(0);
        setCS(0);
        document.getElementById("floor-label").textContent = currentMapData.floors[currentIndexFloor].floor
    }
}





function calculateTargetAnimation(i, p1, p2) {
    const [x1, y1] = p1.cordinatepunti.split(',').map(Number);
    const [x2, y2] = p2.cordinatepunti.split(',').map(Number);
    
    const dx = x2 - x1;
    const dy = y2 - y1;
    const length = Math.hypot(dx, dy);
    const angle = Math.atan2(dy, dx);
    
    return {
        x: (x1 + x2) / 2,
        y: (y1 + y2) / 2,
        scale: Math.min(canvas.height / (length * 1.2)), 
        rotation: (-Math.PI / 2) - angle
    };
}
let floorChangePending = false;
let targetFloor = null;
let currentPathIndex = 0;

function SF() {
    hideFloorChangeAlert();
    if (floorChangePending) {
        const newFloorIndex = currentMapData.floors.findIndex(f => f.floor == targetFloor);
        if (newFloorIndex === -1) return;
        
        currentIndexFloor = newFloorIndex;
        loadFloorData(currentIndexFloor).then(() => {
            loadFloor();
            document.getElementById("floor-label").textContent = targetFloor;
            Step(currentStep); 
            floorChangePending = false; 
            targetFloor = null;
        });
    } else {
        if (currentStep < path.sequence.length - 1) {
            Step(currentStep + 1);
        }
    }
}

function SB() {
    hideFloorChangeAlert();
    

    if (floorChangePending) {
        const newFloorIndex = currentMapData.floors.findIndex(f => f.floor == targetFloor);
        if (newFloorIndex === -1) return;
        
        currentIndexFloor = newFloorIndex;
        loadFloorData(currentIndexFloor).then(() => {
            loadFloor();
            document.getElementById("floor-label").textContent = targetFloor;
            Step(currentStep);
            floorChangePending = false;
            targetFloor = null;
        });
        return;
    }
    
   
    if (currentStep > 0) {
        const prevStep = currentStep - 1;
        const [prevFloor] = path.sequence[prevStep].split('*');
        
      
        if (prevFloor !== currentFloorData.floor.toString()) {
            showFloorChangeAlert(prevFloor);
            floorChangePending = true;
            targetFloor = prevFloor;
            currentStep = prevStep; 
        } else {
            Step(prevStep);
        }
    } else {
        Step(0);
    }
}

let dontdraw = null
function Step(i) {
    if (!path.sequence || i < 0 || i >= path.sequence.length) return;

    hideFloorChangeAlert()

    currentStep = i; 
    setCS(i);       

    const currentPoint = path.sequence[i];
    const [currentFloor, currentName] = currentPoint.split('*');

    // Controllo cambio piano
    if (currentFloor != currentFloorData.floor) {
        showFloorChangeAlert(currentFloor);
        floorChangePending = true;
        targetFloor = currentFloor;
        currentStep = i;
        dontdraw = currentStep
        return;
    }

    floorChangePending = false;
    targetFloor = null;

   
    if (i === 0) {
        targetTransform = { 
            x: canvas.width / 2, 
            y: canvas.height / 2, 
            scale: 1, 
            rotation: 0 
        };
    } else {
        const prevPoint = path.sequence[i-1];
        const [prevFloor, prevName] = prevPoint.split('*');
        
        const p1 = currentFloorData.points.find(p => p.name === prevName);
        const p2 = currentFloorData.points.find(p => p.name === currentName);

        if (!p1 || !p2) return;

        const newTarget = calculateTargetAnimation(i, p1, p2);
        if (newTarget) {
            targetTransform = newTarget;
        } else {
            targetTransform = { ...currentTransform }; // Fallback safety
        }
    }

    // Forza l'aggiornamento dello stato
    currentStep = i;
    setCS(i);
    startAnimation();
    safeApplyTransforms(); // Forza il ridisegno immediato
}

function setCS(i) {
    document.getElementById("step-label").textContent = 
        `Passo ${i} di ${path.sequence.length-1} | Piano ${currentFloorData.floor}`;
}

function showFloorChangeAlert(newFloor) {
    const alert = document.getElementById('floorChangeAlert');
    alert.textContent = `Cambio piano necessario: Dal piano ${currentFloorData.floor} al piano ${newFloor}`;
    alert.style.display = 'block';
}

function hideFloorChangeAlert() {
    const alert = document.getElementById('floorChangeAlert');
    alert.style.display = 'none';
}

function startAnimation() {
    if (animationFrameId) cancelAnimationFrame(animationFrameId);
    animate();
}

function animate() {
    const SPEED = 0.05;
    
    currentTransform.x += (targetTransform.x - currentTransform.x) * SPEED;
    currentTransform.y += (targetTransform.y - currentTransform.y) * SPEED;
    currentTransform.scale += (targetTransform.scale - currentTransform.scale) * SPEED;
    
    let angleDiff = targetTransform.rotation - currentTransform.rotation;
    angleDiff = ((angleDiff + Math.PI) % (2 * Math.PI)) - Math.PI;
    currentTransform.rotation += angleDiff * SPEED;

    safeApplyTransforms();

    if (Math.abs(currentTransform.x - targetTransform.x) > 0.1 ||
        Math.abs(currentTransform.y - targetTransform.y) > 0.1 ||
        Math.abs(currentTransform.scale - (targetTransform.scale)) > 0.001 ||
        Math.abs(angleDiff) > 0.001) {
        animationFrameId = requestAnimationFrame(animate);
    }
}

function needsUpdate() {
    return Math.abs(currentTransform.rotation - targetTransform.rotation) > 0.001 ||
        Math.abs(currentTransform.scale - targetTransform.scale) > 0.001;
}

function safeApplyTransforms() {
    try {
        applyTransforms();
    } catch (error) {
        console.error("Errore nell'applicazione delle trasformazioni:", error);
        // Ripristina lo stato iniziale
        currentTransform = {
            x: canvas.width / 2,
            y: canvas.height / 2,
            scale: 1,
            rotation: 0
        };
        applyTransforms();
    }
}


function applyTransforms() {
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    
    // Applica trasformazioni
    ctx.translate(canvas.width/2, canvas.height/2);
    ctx.rotate(currentTransform.rotation);
    temp = 0.5
    if (currentStep == 0)
       temp = 1
    ctx.scale(currentTransform.scale*temp, currentTransform.scale*temp);
    ctx.translate(-currentTransform.x, -currentTransform.y);

    loadFloor();

    if (currentStep > 0) {
        const prevPoint = path.sequence[currentStep-1];
        const [prevFloor, prevName] = prevPoint.split('*');
        const currentPoint = path.sequence[currentStep];
        const [currentFloor, currentName] = currentPoint.split('*');

        const p1 = currentFloorData.points.find(p => p.name === prevName);
        const p2 = currentFloorData.points.find(p => p.name === currentName);
        
        if (floorChangePending) {
            return
        }

        if (currentStep == dontdraw) {
            return
        }

        if (p1 && p2) {
            const [x1, y1] = p1.cordinatepunti.split(',').map(Number);
            const [x2, y2] = p2.cordinatepunti.split(',').map(Number);
            
            ctx.beginPath();
            ctx.moveTo(x1, y1);
            ctx.lineTo(x2, y2);
            ctx.strokeStyle = 'rgb(0, 255, 34)';
            ctx.lineWidth = 80 / currentTransform.scale;
            ctx.stroke();
        }
    }
}


