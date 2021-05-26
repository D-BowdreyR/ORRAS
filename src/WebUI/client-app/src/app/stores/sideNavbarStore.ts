import { makeAutoObservable, runInAction } from "mobx";

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

    setCollapse = (result: boolean) => {
        this.sider.collapsed = result;
    };

    handleToggle = () => {
        this.sider.collapsed ? this.setCollapse(false) : this.setCollapse(true);
      };
    
    
}