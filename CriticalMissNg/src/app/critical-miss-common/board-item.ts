import { ImageAsset } from "./image-asset";

export interface BoardItem {
    localId: number;
    name: string;
    isToken: boolean;
    width: number;
    height: number;
    xPos: number;
    yPos: number;
    imageAsset: ImageAsset;
}
