import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import LanguageDetector from "i18next-browser-languagedetector";

import enGB from "../src/locales/en-GB/translation.json";
import fr from "../src/locales/fr/translation.json";

const resources = {
  en: {
    translation: enGB
  },
  fr: {
    translation: fr
  }
};
i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    resources,
      lng: "en-GB",
      fallbackLng: "en",
      //  fallbackLng: {
      //    "de": ["es", "en"]
      //   //"default": ["en"]
      // },
    debug: true,
    interpolation: {
      escapeValue: false, 
    },
  });

export default i18n;
