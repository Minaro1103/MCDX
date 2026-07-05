(() => {
  const gachaModal = document.querySelector("[data-gacha-modal]");
  const gachaOpenButton = document.querySelector("[data-gacha-open]");
  const gachaCloseButton = document.querySelector("[data-gacha-close]");
  const gachaRollButton = document.querySelector("[data-gacha-roll]");
  const stage = document.querySelector("[data-summon-stage]");
  const rarity = document.querySelector("[data-rarity]");
  const title = document.querySelector("[data-result-title]");
  const text = document.querySelector("[data-result-text]");

  const luckyModal = document.querySelector("[data-lucky-modal]");
  const luckyOpenButton = document.querySelector("[data-lucky-open]");
  const luckyCloseButton = document.querySelector("[data-lucky-close]");
  const luckyRollButton = document.querySelector("[data-lucky-roll]");
  const fortuneStage = document.querySelector("[data-fortune-stage]");
  const luckyName = document.querySelector("[data-lucky-name]");
  const luckyText = document.querySelector("[data-lucky-text]");

  const gachaResults = [
    { rank: "LEGEND", chance: 1, title: "虹色伝説刃具セット", text: "排出率 1%。全設備がざわつく超大当たりです。", tier: "legend" },
    { rank: "UR", chance: 4, title: "究極コーティングエンドミル", text: "排出率 4%。虹色カプセル演出つきです。", tier: "ur" },
    { rank: "SSR", chance: 8, title: "伝説級コーティング刃具", text: "排出率 8%。金色演出つきの大当たりです。", tier: "ssr" },
    { rank: "SR", chance: 17, title: "高寿命エンドミル", text: "排出率 17%。今日の交換作業が少し楽になります。", tier: "sr" },
    { rank: "R", chance: 30, title: "標準ドリルセット", text: "排出率 30%。安定した一本です。", tier: "r" },
    { rank: "N", chance: 40, title: "予備チップ", text: "排出率 40%。在庫棚にあると安心です。", tier: "n" }
  ];

  const luckyResults = [
    { name: "鈴木 一郎", text: "工具交換の相談をすると、段取りがスムーズに進みます。" },
    { name: "佐藤 花子", text: "改善アイデアを聞くと、今日の作業が少し軽くなります。" },
    { name: "田中 美咲", text: "負荷予測の確認を一緒にすると、見落としを防げます。" },
    { name: "山田 太郎", text: "困ったら声をかけてみてください。今日の運気は協力で上がります。" }
  ];

  function pickWeighted(items) {
    const roll = Math.random() * 100;
    let total = 0;
    for (const item of items) {
      total += item.chance;
      if (roll < total) {
        return item;
      }
    }
    return items[items.length - 1];
  }

  function pick(items) {
    return items[Math.floor(Math.random() * items.length)];
  }

  function renderGachaResult() {
    if (!stage || !rarity || !title || !text) {
      return;
    }

    const result = pickWeighted(gachaResults);
    rarity.textContent = result.rank;
    title.textContent = result.title;
    text.textContent = result.text;

    stage.classList.remove("playing", "n", "r", "sr", "ssr", "ur", "legend");
    void stage.offsetWidth;
    stage.classList.add(result.tier, "playing");
  }

  function renderLuckyResult() {
    if (!fortuneStage || !luckyName || !luckyText) {
      return;
    }

    const result = pick(luckyResults);
    luckyName.textContent = result.name;
    luckyText.textContent = result.text;

    fortuneStage.classList.remove("opened");
    void fortuneStage.offsetWidth;
    fortuneStage.classList.add("opened");
  }

  if (gachaModal && gachaOpenButton && gachaCloseButton && gachaRollButton) {
    gachaOpenButton.addEventListener("click", () => {
      gachaModal.classList.add("open");
      gachaModal.setAttribute("aria-hidden", "false");
      renderGachaResult();
    });

    gachaCloseButton.addEventListener("click", () => {
      gachaModal.classList.remove("open");
      gachaModal.setAttribute("aria-hidden", "true");
    });

    gachaRollButton.addEventListener("click", renderGachaResult);

    gachaModal.addEventListener("click", event => {
      if (event.target === gachaModal) {
        gachaModal.classList.remove("open");
        gachaModal.setAttribute("aria-hidden", "true");
      }
    });
  }

  if (luckyModal && luckyOpenButton && luckyCloseButton && luckyRollButton) {
    luckyOpenButton.addEventListener("click", () => {
      luckyModal.classList.add("open");
      luckyModal.setAttribute("aria-hidden", "false");
      renderLuckyResult();
    });

    luckyCloseButton.addEventListener("click", () => {
      luckyModal.classList.remove("open");
      luckyModal.setAttribute("aria-hidden", "true");
    });

    luckyRollButton.addEventListener("click", renderLuckyResult);

    luckyModal.addEventListener("click", event => {
      if (event.target === luckyModal) {
        luckyModal.classList.remove("open");
        luckyModal.setAttribute("aria-hidden", "true");
      }
    });
  }

  const toolFilterPanel = document.querySelector("[data-tool-filter-panel]");
  const toolFilterButton = document.querySelector("[data-tool-filter-apply]");
  const toolRows = Array.from(document.querySelectorAll("[data-tool-row]"));

  if (toolFilterPanel && toolFilterButton && toolRows.length > 0) {
    toolFilterButton.addEventListener("click", () => {
      const selected = Array.from(toolFilterPanel.querySelectorAll("[data-tool-filter]:checked"))
        .map(input => input.value);

      toolRows.forEach(row => {
        const tags = (row.dataset.toolTags || "").split(" ");
        const visible = selected.length === 0 || selected.some(item => tags.includes(item));
        row.hidden = !visible;
      });
    });
  }
})();
