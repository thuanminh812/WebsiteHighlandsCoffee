import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '../views/HomePage.vue'
import MenuPage from '../views/MenuPage.vue'
import TinTucPage from '../views/TinTucPage.vue'
import CuaHangPage from '../views/CuaHang.vue'
import CuaHangPageByKhuVuc from '../views/CuaHangByKhuVuc.vue'
import GioiThieuPage from '../views/GioiThieuPage.vue'
import TuyenDungPage from '../views/TuyenDung.vue'
import LienHePage from '../views/LienHe.vue'
import GioHangPage from '../views/GioHang.vue'
import TinTucChiTiet from '../views/TinTucChiTiet.vue'
import MenuChiTiet from '../views/MenuChiTiet.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'
import DashBoard from '../components/DashBoard.vue'
import DsachDanhMucMenu from '../views/QlyDanhMucMenu/DsachDanhMucMenu.vue'
import EditDanhMucMenu from '../views/QlyDanhMucMenu/EditDanhMucMenu.vue'
import FormDmucMenu from '../views/QlyDanhMucMenu/Form.vue'
import DsachDanhMucTinTuc from '../views/QlyDanhMucTinTuc/DsachDanhMucTinTuc.vue'
import EditDanhMucTinTuc from '../views/QlyDanhMucTinTuc/EditDanhMucTinTuc.vue'
import FormDmucTinTuc from '../views/QlyDanhMucTinTuc/Form.vue'
import DsachMenu from '../views/QlyMenu/DsachMenu.vue'
import EditMenu from '../views/QlyMenu/EditMenu.vue'
import DsachTinTuc from '../views/QlyTinTuc/DsachTinTuc.vue'
import EditTinTuc from '../views/QlyTinTuc/EditTinTuc.vue'

import DsachCuaHang from '../views/QlyCuaHang/DsachCuaHang.vue'
import EditCuaHang from '../views/QlyCuaHang/EditCuaHang.vue'
import ProfileUser from '../views/ProfileUser.vue'
import DsachKhuVuc from '../views/QlyKhuVuc/DsachKhuVuc.vue'
import EditKhuVuc from '../views/QlyKhuVuc/EditKhuVuc.vue'
import FormKhuVuc from '../views/QlyKhuVuc/Form.vue'
import QlyDonHang from '../views/QlyDonHang/DsachDonHang.vue'
import DonHangChiTiet from '../views/ChiTietDonHang/DsachChiTietDonHang.vue'
import PhanHoiKhachHang from '../views/PhanHoiKhachHang.vue'
import XemDonHang from '../views/XemDonHang.vue'
import AddAdmin from '../views/AddAdmin.vue'
const routes = [

  // {
  //   path: '/',
  //   component: HomePage
  // },
  {
    path: '/addadmin',
    component: AddAdmin
  },
  {
    path: '/profileuser',
    component: ProfileUser
  },
  {
    path: '/menu',
    component: MenuPage
  },
  {
    path: '/tintuc',
    component: TinTucPage
  },
  {
    path: '/cuahang',
    component: CuaHangPage
  },
  {
    path: '/cuahangbykv/:id',
    name:'cuahangbykv',
    component: CuaHangPageByKhuVuc
  },
  {
    path: '/gioithieu',
    component: GioiThieuPage
  },
  {
    path: '/tintuc/:id',
    name: 'tintucchitiet',
    component: TinTucChiTiet
  },
  {
    path: '/menuchitiet/:id',
    name: 'menuchitiet',
    component: MenuChiTiet
  },
  {
    path: '/tuyendung',
    component: TuyenDungPage
  },
  {
    path: '/lienhe',
    component: LienHePage
  },
  {
    path: '/giohang',
    component: GioHangPage
  },
  {
    path: '/',
    name: 'home',
    component: HomePage
  },
  {
    path: '/home',
    component: HomePage
  },
  {
    path: '/login',
    component: Login
  },
  {
    path: '/register',
    component: Register
  },
  {
    path: "/dashboard",
    name: "dashboard",
    // lazy-loaded
    component: DashBoard,
  },
  {
    path: '/editdmucmenu/:id',
    name: "editdmucmenu",
    // lazy-loaded
    component: EditDanhMucMenu,
  },
  {
    path: "/listdmucmenu",
    name: "dsachdmucmenu",
    // lazy-loaded
    component: DsachDanhMucMenu,
  },
  {
    path: "/formdmucmenu",
    name: "formdmucmenu",
    // lazy-loaded
    component: FormDmucMenu,
  },
  {
    path: '/editdmuctintuc/:id',
    name: "editdmuctintuc",
    // lazy-loaded
    component: EditDanhMucTinTuc,
  },
  {
    path: "/listdmuctintuc",
    name: "dsachdmuctintuc",
    // lazy-loaded
    component: DsachDanhMucTinTuc,
  },
  {
    path: "/formdmuctintuc",
    name: "formdmuctintuc",
    // lazy-loaded
    component: FormDmucTinTuc,
  },
  {
    path: '/editmenu/:id',
    name: "editmenu",
    // lazy-loaded
    component: EditMenu,
  },
  {
    path: "/listmenu/:id",
    name: "listmenu",
    // lazy-loaded
    component: DsachMenu,
  },
  {
    path: '/edittintuc/:id',
    name: "edittintuc",
    // lazy-loaded
    component: EditTinTuc,
  },
  {
    path: "/listtintuc/:id",
    name: "listtintuc",
    // lazy-loaded
    component: DsachTinTuc,
  },
  {
    path: "/qlycuahang/:id",
    name: "listcuahang",
    // lazy-loaded
    component: DsachCuaHang,
  },
  {
    path: '/editcuahang/:id',
    name: "editcuahang",
    // lazy-loaded
    component: EditCuaHang,
  },

  {
    path: "/qlykhuvuc",
    name: "listkhuvuc",
    // lazy-loaded
    component: DsachKhuVuc,
  },
  {
    path: "/formkhuvuc",
    name: "formkhuvuc",
    // lazy-loaded
    component: FormKhuVuc,
  },
  {
    path: '/editkhuvuc/:id',
    name: "editkhuvuc",
    // lazy-loaded
    component: EditKhuVuc,
  },
  {
    path: "/phanhoi",
    name: "phanhoi",
    // lazy-loaded
    component: PhanHoiKhachHang,
  },
  {
    path: "/qlydonhang",
    name: "listdonhang",
    // lazy-loaded
    component: QlyDonHang,
  },
  {
    path: '/listchitietdh/:id',
    name: 'listchitietdh',
    // lazy-loaded
    component: DonHangChiTiet,
  },
  {
    path: "/donhangcuaban/:id",
    name: "donhangcuaban",
    // lazy-loaded
    component: XemDonHang,
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

