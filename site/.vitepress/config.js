import { defineConfig } from "vitepress"

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Кощей Роман",
  description: "Завдання з ООП",

  base: "/oop/",
  cleanUrls: true,

  markdown: {
    math: true,
  },

  themeConfig: {
    nav: [{ text: "Лабораторні", link: "/labs/1" }],

    sidebar: [
      {
        text: "Лабораторні роботи",
        items: [
          { text: "Лабораторна робота №1", link: "/labs/1" },
          { text: "Лабораторна робота №2", link: "/labs/2" },
          { text: "Лабораторна робота №3", link: "/labs/3" },
          { text: "Лабораторна робота №4", link: "/labs/4" },
          { text: "Лабораторна робота №5", link: "/labs/5" },
        ],
      },
    ],

    socialLinks: [{ icon: "github", link: "https://github.com/koshcher/oop" }],
  },
})
