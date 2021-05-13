import { makeAutoObservable } from "mobx";

interface Sider {
    collapsed: boolean;
}

export default class SideNavBarStore {
    sider: Sider = {
        collapsed: false
    }
    constructor() {
        makeAutoObservable(this);
    }

    handleToggle = () => {
        this.sider.collapsed ? this.sider.collapsed = false : this.sider.collapsed = true;
      };
    
}



