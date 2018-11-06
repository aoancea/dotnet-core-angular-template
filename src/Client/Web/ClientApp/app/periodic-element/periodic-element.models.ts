export interface PeriodicElement {
    name: string;
    position: number;
    weight: number;
    symbol: string;
    isotopes: Isotope[];
}

export interface Isotope {
    name: string;
}