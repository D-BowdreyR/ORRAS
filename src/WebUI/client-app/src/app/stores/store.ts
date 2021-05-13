import { createContext, useContext } from "react"
import ModalStore from "./modalStore";
import SideNavBarStore from "./sideNavbarStore";
import UserStore from "./userStore";

interface Store {
    sideNavbarStore: SideNavBarStore;
    userStore: UserStore;
    modalStore: ModalStore;
}
export const store: Store = {
    sideNavbarStore: new SideNavBarStore(),
    userStore: new UserStore(),
    modalStore: new ModalStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}