import Home from "./pages/home/Home";
import User from "./pages/user/User";
import Asset from "./pages/asset/Asset";
import Assignment from "./pages/assignment/Assignment";
import Request from "./pages/request/Request";
import Report from "./pages/report/Report";
import assetForm from "./pages/assetForm/assetForm";
import userForm from "./pages/userForm/userForm";

export const routePaths = [
  {
    path: "/",
    title: "Home",
    component: Home,
    exact: true,
    any: true,
  },
  {
    path: "/users",
    title: "Manage User",
    component: User,
    exact: true,
  },
  {
    path: "/assets",
    title: "Manage Asset",
    component: Asset,
    exact: true,
  },
  {
    path: "/assignments",
    title: "Manage Assignment",
    component: Assignment,
  },
  {
    path: "/requests",
    title: "Manage Request",
    component: Request,
  },
  {
    path: "/report",
    title: "Report",
    component: Report,
  },
  {
    path: "/new-asset",
    title: "Manage Asset > Create New Asset",
    component: assetForm,
  },
  {
    path: "/assets/:id",
    title: "Manage Asset > Edit Asset",
    component: assetForm,
  },
  {
    path: "/new-user",
    title: "Manage User > Create New User",
    component: userForm,
  },
  {
    path: "/users/:id",
    title: "Manage User > Edit User",
    component: userForm,
  },
];
