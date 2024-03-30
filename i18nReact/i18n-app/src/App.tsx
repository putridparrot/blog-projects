import React from "react";
import "./App.css";
import { useTranslation } from "react-i18next";

const lngs: any = {
  en: { nativeName: "English"},
  fr: { nativeName: "French"},
  de: { nativeName: "German"},
}

function App() {
  const { t, i18n } = useTranslation();

  return (
    <div className="App">
      <div className="App-header">
        <div>{`Browser Language ${navigator.language}`}</div>
        <div>{`i18next Language ${i18n.resolvedLanguage}`}</div>
        {t("welcome")}
        <div>
          {Object.keys(lngs).map(lng => {
            return <button key={lng} style={{margin: "3px", padding: "6px"}}
              onClick={() => i18n.changeLanguage(lng)} disabled={i18n.resolvedLanguage === lng}>{lngs[lng].nativeName}</button>
          })}
        </div>
      </div>
    </div>
  );
}

export default App;
