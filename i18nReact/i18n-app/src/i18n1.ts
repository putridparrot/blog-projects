import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import LanguageDetector from "i18next-browser-languagedetector";

i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    //lng: "en-GB",
    // fallbackLng: {
    //   "en" : ["en-GB"]
    // },
    resources: {
      en: {
        translation: {
          welcome: "code: Hello string en World"
        },
      },
      fr: {
        translation: {
          welcome: "code: Bonjour string fr World"
        }
      }
    },
    debug: true,
    interpolation: {
      escapeValue: false, 
    },
  });

export default i18n;
