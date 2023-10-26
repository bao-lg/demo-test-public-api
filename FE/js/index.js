const handleOpenTab = (tab) => {
  const duckEl = document.getElementById("duckTab");
  const dogEl = document.getElementById("dogTab");
  const catEl = document.getElementById("catTab");
  const homeEl = document.getElementById("home");
  duckEl.hidden = true;
  dogEl.hidden = true;
  catEl.hidden = true;
  homeEl.hidden = true;

  switch (tab) {
    case "home":
      home.hidden = false;
      break;
    case "dog":
      dogEl.hidden = false;
      break;
    case "duck":
      duckEl.hidden = false;
      break;
    case "cat":
      catEl.hidden = false;
      break;
    default:
      break;
  }
};

const handleDogImage = async () => {
  const dogImg = await fetch(
    "https://localhost:7299/Practice/GetDogImageAsync",
  );
  if (dogImg.status !== 200) {
    alert("Cannot get new data");
  }
  const myJson = await dogImg.json();
  const dogEl = document.getElementById("dogImg");
  if (myJson && dogEl) {
    dogEl.hidden = true;
    dogEl.src = myJson.message;
    dogEl.hidden = false;
  }
};

const handleDuckImage = async () => {
  const duckImg = await fetch(
    "https://localhost:7299/Practice/GetDuckImageAsync",
  );
  if (duckImg.status !== 200) {
    alert("Cannot get new data");
  }
  const myJson = await duckImg.json();
  const dogEl = document.getElementById("duckImg");
  if (myJson && dogEl) {
    dogEl.hidden = true;
    dogEl.src = myJson.url;
    dogEl.hidden = false;
  }
};

const handCatFactsLang = async (lang) => {
  const catFacts = await fetch(
    `https://localhost:7299/Practice/GetCatFactsAsync?${new URLSearchParams({
      lang,
    })}`,
  );
  if (catFacts.status !== 200) {
    alert("Cannot get new data");
  }
  const myJson = await catFacts.json();
  const listEl = document.getElementById("myList");
  if (myJson && listEl) {
    listEl.hidden = true;
    myJson?.data?.forEach((element) => {
      const node = document.createElement("li");
      const textnode = document.createTextNode(element);
      node.appendChild(textnode);
      listEl.appendChild(node);
    });

    listEl.hidden = false;
  }
};
